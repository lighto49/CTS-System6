using CTS_System6.Data;
using CTS_System6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.ViewModels
{
    public class UserProfileVM
    {

        //User Attributes
        public string UserId { get; set; }

        public int ProjectsCount { get; set; }
        public int AccomplishedProjects { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Country { get; set; }
        //public byte[] ProfilePictuer { get; set; }
        //public float Rate { get; set; }
        //public DateTime RegestrationDate { get; set; }

        //Rate Attributes
        //public int RateId { get; set; }
        //public int DeliveryScale { get; set; }
        //public int QualityScale { get; set; }
        //public int CommunicationScale { get; set; }
        //public DateTime RateDate { get; set; }
        //public string Review { get; set; }

        public List<ApplicationUser> UserInfo { get; set; }
        public List<Rate> RateList { get; set; }


    }
}
