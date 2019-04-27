using MyCleverApp.Chat.Dto;
using MyCleverApp.Chat.Dto.Messages;
using MyCleverApp.Chat.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCleverApp.Chat.Services
{
    public class MessageService : IMessageService
    {
        public ServiceResult<bool> SendMessage(SendMessageDto request)
        {
            return new ServiceResult<bool>
            {
                Result = true,
                StatusCode = StatusCodeType.Success
            };
        }
    }
}
