using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Models
{
    public class Languages
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        //public List<Projects> ProjectsList { get; set; }
        //public List<TranslatorsLanguages> TranslatorsLanguagesList { get; set; }
        public virtual ICollection<Projects> PFromLanguages { get; set; }
        public virtual ICollection<Projects> PToLanguages { get; set; }
        public virtual ICollection<TranslatorsLanguages> TFromLanguages { get; set; }
        public virtual ICollection<TranslatorsLanguages> TToLanguages { get; set; }
    }
}
