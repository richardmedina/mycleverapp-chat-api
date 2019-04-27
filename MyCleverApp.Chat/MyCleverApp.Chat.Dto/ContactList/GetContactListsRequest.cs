using System;
using System.Collections.Generic;
using System.Text;

namespace MyCleverApp.Chat.Dto.ContactList
{
    public class GetContactListsRequest : ServiceRequest
    {
        public string UserName { get; set; }
    }
}
