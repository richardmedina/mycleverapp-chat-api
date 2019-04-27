using MyCleverApp.Chat.Dto;
using MyCleverApp.Chat.Dto.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCleverApp.Chat.Services.Interfaces
{
    public interface IMessageService
    {
        ServiceResult<bool> SendMessage(SendMessageDto request);
    }
}
