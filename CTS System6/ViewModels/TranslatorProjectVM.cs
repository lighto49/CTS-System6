using CTS_System6.Data;
using CTS_System6.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DeliveryDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
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
        public string Review { get; set; }
        public int DeliveryScale { get; set; }
        public int QualityScale { get; set; }
        public int CommunicationScale { get; set; }
        public string Selected { get; set; }

        public List<Rate> BRate { get; set; }
        public bool Authorized { get; set; }






        ///new version of view model
        ///


        public List<Rate> TranslatorRate { get; set; }
        public List<Rate> CustomerRate { get; set; }
        public List<Projects> ProjectInfo { get; set; }
        public List<Bids> Bid { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string BidBody { get; set; }
        public int BidOffer { get; set; }
        public bool RateAuth { get; set; }
        public bool RateFlag { get; set; }
        public bool CustomerRateFlag { get; set; }
        public bool BidFlag { get; set; }


    }
}
