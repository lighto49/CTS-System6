using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Models
{
    public class TranslatorsLanguages
    { 
        public int Id { get; set; }
        public string TranslatorId { get; set; }
        public int FromLanguageId { get; set; }
        public int ToLanguageId { get; set; }
        public bool Status { get; set; }
        //[ForeignKey("TranslatorId")]
        //public ApplicationUser ApplicationUser { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        //[ForeignKey("FromLanguage, ToLanguage")]
        //public Languages Languages { get; set; }
        public virtual Languages FromLanguage { get; set; }
        public virtual Languages ToLanguage { get; set; }
    }
}
