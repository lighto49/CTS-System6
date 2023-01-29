using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Models
{
    public class Projects
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int FromLanguageId { get; set; }
        public int ToLanguageId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; }
        public float Offer { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime PostDate { get; set; }

        public string SelectedTranslator { get; set; }

        //[ForeignKey("CustomerId")]
        //public ApplicationUser ApplicationUser { get; set; }
        //[ForeignKey("FromLanguage, ToLanguage")]
        //public Languages Languages { get; set; }
        //public List<Bids> BidsList { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Bids> BidsList { get; set; }
        public virtual Languages FromLanguage { get; set; }
        public virtual Languages ToLanguage { get; set; }

    }
}
