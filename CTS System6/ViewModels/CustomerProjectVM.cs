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
        IEnumerable<ApplicationUser> users { get; set; }
        IEnumerable<Languages> languages { get; set; }

        public string BidsCount { get; set; }
    }
}
