using CTS_System6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.ViewModels
{
    public class TranslatorProjectVM
    {
        //project attributes
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int FromLanguage { get; set; }
        public int ToLanguage { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; }
        public float Offer { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime PostDate { get; set; }

        //languages attributes
        public string FromLanguageName { get; set; }
        public string ToLanguageName { get; set; }

        //users attributes

        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }

        //bids attributes
        public string BidsCount { get; set; }
        public string BBody { get; set; }
        public float BOffer { get; set; }
        public string BCurrency { get; set; }
        public string TranslatorFirstName { get; set; }
        public string TranslatorLastName { get; set; }
        public int BidStatus { get; set; }
        public string TranslatorId { get; set; }

        //Workflow attributes
        public string SelectedTranslator { get; set; }



    }
}
