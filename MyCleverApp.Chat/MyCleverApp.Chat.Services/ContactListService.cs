using AutoMapper;
using MyCleverApp.Chat.Dto;
using MyCleverApp.Chat.Dto.ContactList;
using MyCleverApp.Chat.Model;
using MyCleverApp.Chat.Model.Entities;
using MyCleverApp.Chat.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCleverApp.Chat.Services
{
    public class ContactListService : ServiceBase, IContactListService
    {
        private readonly ChatDbContext _context;
        private readonly IMapper _mapper;
        public ContactListService(ChatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ServiceResult<IEnumerable<ContactListDto>> GetContactLists(GetContactListsRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == request.UserName);

            if (user == null) return GetFailedResult<IEnumerable<ContactListDto>>(request,  
                new ErrorMessage
                {
                    Text = "User Not Found"
                });

            var listsDto = _mapper.Map<IEnumerable<ContactListDto>>(user.ContactLists);

            return GetSuccessResult(request, listsDto);
        }

        public ServiceResult<ContactListDto> CreateContactList (CreateContactListDto request)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == request.OwnerUserName);

            if (user == null) return GetFailedResult<ContactListDto>(request, new ErrorMessage { Text = "User Not Found" });

            var list = _context.ContactLists.Add(new ContactList
            {
                Name = request.ContactListName,
                Description = request.ContactListDescription,
                OwnerUser = user
            });

            _context.SaveChanges();

            return GetSuccessResult(request, _mapper.Map<ContactListDto> (list.Entity));
        }
    }
}
