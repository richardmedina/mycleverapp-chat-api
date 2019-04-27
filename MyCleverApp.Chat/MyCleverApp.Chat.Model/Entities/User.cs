using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyCleverApp.Chat.Model.Entities
{
    [Table(nameof(User))]
    public class User : EntityBase
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        /* Navigation Properties */
        public long? ContactInfoId { get; set; }

        [ForeignKey(nameof(ContactInfoId))]
        public ContactInfo ContactInfo { get; set; }
        public virtual List<ContactList> ContactLists { get; set; }
    }
}
