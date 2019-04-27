using MyCleverApp.Chat.Dto;
using MyCleverApp.Chat.Dto.ContactList;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCleverApp.Chat.Services.Interfaces
{
    public interface IContactListService
    {
        ServiceResult<IEnumerable<ContactListDto>> GetContactLists(GetContactListsRequest request);
        ServiceResult<ContactListDto> CreateContactList(CreateContactListDto request);
    }
}
