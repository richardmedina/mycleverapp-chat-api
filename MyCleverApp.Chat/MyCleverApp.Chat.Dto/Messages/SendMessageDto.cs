using System;
using System.Collections.Generic;
using System.Text;

namespace MyCleverApp.Chat.Dto.Messages
{
    public class SendMessageDto : ServiceRequest
    {
        public string Recipient { get; set; }
        public string Message { get; set; }
    }
}
