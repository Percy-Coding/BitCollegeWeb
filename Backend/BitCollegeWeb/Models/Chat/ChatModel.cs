using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.Chat
{
    public class ChatModel
    {
        public int ChatId { get; set; }
        public string Content { get; set; }
        public int? ClassroomId { get; set; }
        public int? TeacherId { get; set; }
    }
}
