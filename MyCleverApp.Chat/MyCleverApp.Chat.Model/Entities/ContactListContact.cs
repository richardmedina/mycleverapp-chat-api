using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyCleverApp.Chat.Model.Entities
{
    [Table(nameof(ContactListContact))]
    public class ContactListContact : EntityBase
    {
        public long Id { get; set; }

        [ForeignKey(nameof(ContactInfo))]
        public long ContactInfoId { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }

        [ForeignKey(nameof(ContactList))]
        public long ContactListId { get; set; }
        public virtual ContactList ContactList { get; set; }
    }
}
