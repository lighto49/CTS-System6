using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public string UserAId { get; set; }
        public ApplicationUser UserA { get; set; }
        public string UserBId { get; set; }
        public ApplicationUser UserB { get; set; }
        public DateTime StartDate { get; set; }
        public bool Status { get; set; }
        public List<Message> Messages { get; set; }
    }
}
