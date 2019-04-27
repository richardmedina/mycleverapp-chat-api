using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCleverApp.Chat.Api.Models.Messages
{
    public class PostMessage
    {
        public string Recipient { get; set; }
        public string Message { get; set; }
    }
}
