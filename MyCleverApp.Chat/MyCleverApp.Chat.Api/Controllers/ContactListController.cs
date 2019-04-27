using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyCleverApp.Chat.Api.Models.ContactList;
using MyCleverApp.Chat.Dto.ContactList;
using MyCleverApp.Chat.Services.Interfaces;

namespace MyCleverApp.Chat.Api.Controllers
{
    [Route("[controller]")]
    public class ContactListController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IContactListService _contactListService;
        public ContactListController(IMapper mapper, IContactListService contactListService)
        {
            _mapper = mapper;
            _contactListService = contactListService;
        }

        public IActionResult Index()
        {
            var request = _mapper.Map<GetContactListsRequest>(GetCurrentUserName ());

            var result = _contactListService.GetContactLists(request);

            return Ok (result);
        }

        [HttpPost]
        public IActionResult Post ([FromBody] CreateContactListModel model)
        {
            var dto = _mapper.Map<CreateContactListDto>(model);
            dto.OwnerUserName = GetCurrentUserName();

            var result = _contactListService.CreateContactList(dto);

            return Ok();
        }
        
    }
}