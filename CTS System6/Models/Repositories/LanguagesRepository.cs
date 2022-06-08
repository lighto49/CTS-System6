using CTS_System6.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Models.Repositories
{
    public class LanguagesRepository : ITranslatorRepository<Languages>
    {
        TranslatorAppDbContext db;
        public LanguagesRepository(TranslatorAppDbContext _db)
        {
            db = _db;
        }

        public void Add(Languages entity)
        {
            db.Languages.Add(entity);
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            var language = Find(id);
            db.Languages.Remove(language);
            db.SaveChanges();
        }

        public Languages Find(string id)
        {
            var language = db.Languages.SingleOrDefault(b => b.Id.ToString() == id);
            return language;
        }

        public IList<Languages> List()
        {
            return db.Languages.ToList();
        }

        public void Update(string id, Languages newLanguage)
        {
            db.Update(newLanguage);
            db.SaveChanges();
        }
    }
}
