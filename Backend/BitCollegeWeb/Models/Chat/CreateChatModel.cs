using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.Chat
{
    public class CreateChatModel
    {
        public string Content { get; set; }
        public int? ClassroomId { get; set; }
        public int? TeacherId { get; set; }
    }
}
