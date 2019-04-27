using System;
using System.Collections.Generic;
using System.Text;

namespace MyCleverApp.Chat.Dto.ContactList
{
    public class ContactListDto
    {
        public long Id { get; set; }
        public long OwnerUserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ContactInfoDto> Contacts { get; set; }
    }
}
