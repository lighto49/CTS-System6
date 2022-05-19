using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Models
{
    public class Bids
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string TranslatorId { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
        public float Offer { get; set; }
        public string Currency { get; set; }

        //[ForeignKey("TranslatorId")]
        public ApplicationUser ApplicationUser { get; set; }
        //[ForeignKey("ProjectId")]
        public Projects Projects { get; set; }
    }
}
