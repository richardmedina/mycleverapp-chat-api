using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyCleverApp.Chat.Model.Entities
{
    [Table(nameof(ContactList))]
    public class ContactList : EntityBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(OwnerUser))]
        public long OwnerUserId { get; set; }
        public virtual User OwnerUser { get; set; }
        
        public virtual List<ContactListContact> ContactListContact { get; set; }
    }
}
