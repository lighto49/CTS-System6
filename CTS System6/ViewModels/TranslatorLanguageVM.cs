using CTS_System6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.ViewModels
{
    public class TranslatorLanguageVM
    {
        public int Id { get; set; }
        public int FromLanguageId { get; set; }
        public int ToLanguageId { get; set; }
        public bool Status { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
    }


}
