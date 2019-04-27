using System;
using System.Collections.Generic;
using System.Text;

namespace MyCleverApp.Chat.Dto.ContactList
{
    public class GetContactListsResult
    {
        public IEnumerable<ContactListDto> ContactLists { get; set; }
    }
}
