using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyCleverApp.Chat.Api.Models.Messages;
using MyCleverApp.Chat.Dto.Messages;
using MyCleverApp.Chat.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCleverApp.Chat.Api.Controllers
{
    [Route ("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        public MessagesController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }
        /// <summary>
        /// Sends a message to a given recipient
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostMessage ([FromBody] MessagePostModel messagePostModel)
        {
            var guid = Guid.NewGuid().ToString();
            var dto = _mapper.Map<SendMessageDto>(messagePostModel);

            return Ok(_messageService.SendMessage(dto));
        }
    }
}
