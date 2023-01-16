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
        public int FromLanguage { get; set; }
        public int ToLanguage { get; set; }

        public bool Status { get; set; }
        //[ForeignKey("TranslatorId")]
        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("FromLanguage, ToLanguage")]
        public Languages Languages { get; set; }
    }
}
