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
        public  int DeliveryScale { get; set; }
        public  int QualityScale { get; set; }
        public  int CommunicationScale { get; set; }
        public  DateTime RateDate { get; set; }

        //[ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
