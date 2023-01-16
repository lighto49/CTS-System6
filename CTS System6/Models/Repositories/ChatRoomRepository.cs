using CTS_System6.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Models.Repositories
{
    public class ChatRoomRepository : ITranslatorRepository<ChatRoom>
    {
        ApplicationDbContext db;
        public ChatRoomRepository(ApplicationDbContext _db)
        {
            db = _db;
        }

        public void Add(ChatRoom entity)
        {
            db.ChatRooms.Add(entity);
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public ChatRoom Find(string id)
        {
            throw new NotImplementedException();
        }

        public IList<ChatRoom> List()
        {
            return db.ChatRooms.ToList();
        }

        public IList<ChatRoom> List(string id)
        {
            return db.ChatRooms.Where(c => c.UserAId == id || c.UserBId == id).ToList();
        }

        public void Update(string id, ChatRoom newChat)
        {
            db.Update(newChat);
            db.SaveChanges();
        }

        public void UpdateElement(string elementId, string elementName, string newValue)
        {
            throw new NotImplementedException();
        }
    }
}
