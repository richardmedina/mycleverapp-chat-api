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
        public string UserName { get; set; }
        public string Password { get; set; }
        [ForeignKey(nameof(ContactInfo))]
        public long? ContactInfoId { get; set; }
        /* Navigation Properties */
        public virtual ContactInfo ContactInfo { get; set; }
        public virtual List<ContactList> ContactLists { get; set; }
    }
}
