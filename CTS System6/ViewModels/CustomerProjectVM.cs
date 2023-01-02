using CTS_System6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.ViewModels
{
    public class CustomerProjectVM
    {
        public List<Projects> pp { get; set; }
        public List<TranslatorProjectVM> cc { get; set; }
        //IEnumerable<ApplicationUser> users { get; set; }
        //IEnumerable<Languages> languages { get; set; }


        //Project's workflow attributs
        public int Id { get; set; }
        public string Status { get; set; }
        public string SelectedTranslator { get; set; }

        //Rating attributs
        public string CreatedBy { get; set; }
        public int DeliveryScale { get; set; }
        public int QualityScale { get; set; }
        public int CommunicationScale { get; set; }
        public DateTime RateDate { get; set; }
        public string Review { get; set; }

        //Bid attributs
        public string BidsCount { get; set; }
        //public string CurrentStatus { get; set; }
    }
}
