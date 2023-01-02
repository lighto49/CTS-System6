using CTS_System6.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Models.Repositories
{
    public class MessageRepository : ITranslatorRepository<Message>
    {
        ApplicationDbContext db;
        public MessageRepository(ApplicationDbContext _db)
        {
            db = _db;
        }

        public void Add(Message entity)
        {
            db.Messages.Add(entity);
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Message Find(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Message> List()
        {
            return db.Messages.ToList();
        }

        public IList<Message> List(string id)
        {
            return db.Messages.Where(m => m.ChatRoomId == Convert.ToInt32(id)).OrderBy(m => m.SendDate).ToList();
        }

        public void Update(string id, Message entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateElement(string elementId, string elementName, string newValue)
        {
            throw new NotImplementedException();
        }
    }
}
