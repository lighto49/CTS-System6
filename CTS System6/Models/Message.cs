using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int ChatRoomId { get; set; }
        public ChatRoom ChatRoom { get; set; }
        public string UserId { get; set; }
        public DateTime SendDate { get; set; }
    }
}
