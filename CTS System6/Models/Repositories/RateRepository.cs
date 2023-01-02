using CTS_System6.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Models.Repositories
{
    public class RateRepository : ITranslatorRepository<Rate>
    {
        ApplicationDbContext db;
        public RateRepository(ApplicationDbContext _db)
        {
            db = _db;
        }
        public void Add(Rate entity)
        {
            db.Rate.Add(entity);
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            var rate = Find(id);
            db.Rate.Remove(rate);
            db.SaveChanges();
        }

        public Rate Find(string id)
        {
            var rate = db.Rate.SingleOrDefault(b => b.Id.ToString() == id);
            return rate;
        }

        public IList<Rate> List()
        {
            return db.Rate.ToList();
        }

        public IList<Rate> List(string id)
        {
            var relatedRate = db.Rate.Where(x => x.UserId == id).ToList();
            return relatedRate;
        }

        public void Update(string id, Rate newRate)
        {
            db.Update(newRate);
            db.SaveChanges();
        }


        public void UpdateElement(string elementId, string elementName, string newValue)
        {
            throw new NotImplementedException();
        }
    }
}
