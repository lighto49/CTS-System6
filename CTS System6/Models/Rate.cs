using CTS_System6.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Data
{
    public class Rate
    {
        public int Id { get; set; }
        public  string UserId { get; set; }
        public  string CreatedBy { get; set; }
        public int ProjectId { get; set; }
        [Required]
        public int DeliveryScale { get; set; }
        [Required]
        public int QualityScale { get; set; }
        [Required]
        public int CommunicationScale { get; set; }
        public  DateTime RateDate { get; set; }
        [Required]
        public string Review { get; set; }

        //[ForeignKey("ProjectId")]
        //public Projects Project { get; set; }
        public virtual Projects Project { get; set; }

    }
}
