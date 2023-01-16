using CTS_System6.Data;
using CTS_System6.Models;
using CTS_System6.Models.Repositories;
using CTS_System6.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CTS_System6.Controllers
{
    public class ChatController : Controller
    {

        private readonly ITranslatorRepository<Message> messageRepository;
        private readonly ITranslatorRepository<ChatRoom> chatroomRepository;

        ApplicationDbContext db;

        public ChatController(ITranslatorRepository<Message> messageRepository, ApplicationDbContext _db, ITranslatorRepository<ChatRoom> chatroomRepository)
        {
            db = _db;
            this.messageRepository = messageRepository;
            this.chatroomRepository = chatroomRepository;
        }
        public IActionResult ViewAllChats()
        {
            var chats = chatroomRepository.List();
            return View(chats);
        }
        public IActionResult ViewUserChats()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userChats = chatroomRepository.List(id);
            return View(userChats);
        }

        public IActionResult ChatDetails(int chatId)
        {
            var members = db.ChatRooms.Where(c => c.Id == chatId).Select(c => new { c.UserAId, c.UserBId, c.Status }).SingleOrDefault();
            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var reciverId = "";
            if (currentUser == members.UserAId)
            {
                reciverId = db.ChatRooms.Where(c => c.Id == chatId).Select(c => c.UserBId).FirstOrDefault();
            }
            else if(currentUser == members.UserBId)
            {
                reciverId = db.ChatRooms.Where(c => c.Id == chatId).Select(c => c.UserAId).FirstOrDefault();
            }

            ViewBag.ReciverId = reciverId;
            ViewBag.SenderId = currentUser;
            var ChatMessages = messageRepository.List(Convert.ToString(chatId)).ToList();
            var model = new MessagesVM { 

                Messages = ChatMessages,
                Sender = currentUser,
                Recevier = reciverId,
                RoomId = chatId,
                Status = members.Status

            };

            return View(model);
        }

        //[HttpPost]
        //public IActionResult ChatDetails(int chatId)
        //{

        //}

        public IActionResult CreateChat(string userBId)
        {
            var userAId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var RoomId = db.ChatRooms.Where(c => (c.UserAId == userAId && c.UserBId == userBId) || (c.UserAId == userBId && c.UserBId == userAId)).Select(c => c.Id).SingleOrDefault();

            if(RoomId > 0)
            {
                // add users to the signalr group

                return RedirectToAction(controllerName: "Chat", actionName: "ChatDetails", routeValues: new { chatId = RoomId });
            }
            else
            {
                var newRoom = new ChatRoom
                {
                    UserAId = userAId,
                    UserBId = userBId,
                    StartDate = DateTime.Now,
                    Status = true
                };
                chatroomRepository.Add(newRoom);
                RoomId = db.ChatRooms.Where(c => c.UserAId == userAId && c.UserBId == userBId).Select(c => c.Id).SingleOrDefault();
                // add users to the signalr group
                return RedirectToAction(controllerName: "Chat", actionName: "ChatDetails", routeValues: new { chatId = RoomId });
            }
        }


        [HttpPost]
        public JsonResult SaveMessage(string roomId, string Text)
        {
            var status = db.ChatRooms.Where(r => r.Id == Convert.ToInt32(roomId)).Select(r => r.Status).FirstOrDefault();
            if (!status)
            {
                return Json("false");
            }
            else
            {
                var message = new Message
                {
                    ChatRoomId = Convert.ToInt32(roomId),
                    SendDate = DateTime.Now,
                    Text = Text,
                    UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value
                };
                messageRepository.Add(message);

                return Json("true");
            }
        }

        public ActionResult Block(int roomId)
        {
            var Room = db.ChatRooms.Where(r => r.Id == roomId).FirstOrDefault();

            Room.Status = !Room.Status;

            chatroomRepository.Update(Convert.ToString(roomId), Room);

            return RedirectToAction(nameof(ChatDetails), new { chatId = roomId});
        }
    }
}
