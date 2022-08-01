using CTS_System6.Data;
//using CTS_System6.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Models.Repositories
{
    public class TranslatorsLanguagesRepository : ITranslatorRepository<TranslatorsLanguages>
    {

        //List<TranslatorsLanguages> translatorLanguages;
        ApplicationDbContext db;


        public TranslatorsLanguagesRepository(ApplicationDbContext _db)
        {
            //translatorLanguages = new List<TranslatorsLanguages>();
            db = _db;
        }

        public void Add(TranslatorsLanguages entity)
        {
            db.TranslatorsLanguages.Add(entity);
            // translatorLanguages.Add(entity);
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            var languages = Find(id);
            db.TranslatorsLanguages.Remove(languages);
            //translatorLanguages.Remove(languages);
            db.SaveChanges();

        }

        public TranslatorsLanguages Find(string id)
        {
            var languages = db.TranslatorsLanguages.SingleOrDefault(t => t.Id.ToString() == id);//translatorLanguages.SingleOrDefault(b => b.TranslatorId == id);
            return languages;
        }

        public IList<TranslatorsLanguages> List(string userid)
        {

            return db.TranslatorsLanguages.Where(x =>x.TranslatorId == userid).ToList();
        }

        public IList<TranslatorsLanguages> List()
        {
            throw new NotImplementedException();
        }

        public void Update(string id, TranslatorsLanguages newTranslatorLanguages)
        {
            /*var languages = Find(id);
            languages.FromLanguage = newTranslatorLanguages.FromLanguage;
            languages.FromLanguage = newTranslatorLanguages.ToLanguage;*/
            db.Update(newTranslatorLanguages);
            db.SaveChanges();


        }
    }
}
