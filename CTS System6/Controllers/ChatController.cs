using CTS_System6.Data;
using CTS_System6.Models;
using CTS_System6.Models.Repositories;
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
            return View();
        }

        public IActionResult ChatDetails(int chatId)
        {
            ViewBag.ReciverId = db.ChatRooms.Where(c => c.Id == chatId).Select(c => c.UserBId);
            var ChatMessages = messageRepository.List(Convert.ToString(chatId));
            return View(ChatMessages);
        }
        
        public IActionResult CreateChat(string userBId)
        {
            var userAId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var RoomId = db.ChatRooms.Where(c => c.UserAId == userAId && c.UserBId == userBId).Select(c => c.Id);

            if(RoomId is not null)
            {
                // add users to the signalr group
                RedirectToAction(controllerName: "Chat", actionName: "ChatDetails", routeValues: new { chatId = RoomId });
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
                RoomId = db.ChatRooms.Where(c => c.UserAId == userAId && c.UserBId == userBId).Select(c => c.Id);
                // add users to the signalr group
                RedirectToAction(controllerName: "Chat", actionName: "ChatDetails", routeValues: new { chatId = RoomId });
            }
            return View();
        }
        
        [HttpPost]
        public IActionResult SendMessage()
        {

        }
    }
}
