using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Models.Repositories
{
    public class TranslatorsLanguagesRepository : ITranslatorRepository<TranslatorsLanguages>
    {

        List<TranslatorsLanguages> translatorLanguages;

        public TranslatorsLanguagesRepository()
        {
            translatorLanguages = new List<TranslatorsLanguages>();
        }

        public void Add(TranslatorsLanguages entity)
        {
            translatorLanguages.Add(entity);
        }

        public void Delete(string id)
        {
            var languages = Find(id);
            translatorLanguages.Remove(languages);
        }

        public TranslatorsLanguages Find(string id)
        {
            var languages = translatorLanguages.SingleOrDefault(b => b.TranslatorId == id);
            return languages;
        }

        public IList<TranslatorsLanguages> List()
        {
            return translatorLanguages;
        }

        public void Update(string id, TranslatorsLanguages newTranslatorLanguages)
        {
            var languages = Find(id);
            languages.FromLanguage = newTranslatorLanguages.FromLanguage;
            languages.FromLanguage = newTranslatorLanguages.ToLanguage;

        }
    }
}
