using CTS_System6.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Country { get; set; }
        public float Rate { get; set; }
        public byte[] ProfilePictuer { get; set; }

        public List<Bids> BidsList { get; set; }
        public List<Rate> RateList { get; set; }
        public List<TranslatorsLanguages> TranslatorLanguagesList { get; set; }
        public List<Projects> ProjectsList { get; set; }


    }
}
