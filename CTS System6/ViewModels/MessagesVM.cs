using CTS_System6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.ViewModels
{
    public class MessagesVM
    {
        public List<Message> Messages { get; set; }
        public int RoomId { get; set; }
        public string Text { get; set; }
        public string Sender { get; set; }
        public string Recevier { get; set; }
        public bool Status { get; set; }


    }
}
