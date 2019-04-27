using System;
using System.Collections.Generic;
using System.Text;

namespace MyCleverApp.Chat.Dto.ContactList
{
    public class CreateContactListDto : ServiceRequest
    {
        public string OwnerUserName { get; set; }
        public string ContactListName { get; set; }
        public string ContactListDescription { get; set; }
    }
}
