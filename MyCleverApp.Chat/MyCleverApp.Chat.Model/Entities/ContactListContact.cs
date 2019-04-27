using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyCleverApp.Chat.Model.Entities
{
    [Table(nameof(ContactListContact))]
    public class ContactListContact
    {
        public long Id { get; set; }

        public long ContactInfoId { get; set; }

        [ForeignKey(nameof(ContactInfoId))]
        public virtual ContactInfo ContactInfo { get; set; }

        public long ContactListId { get; set; }
        [ForeignKey(nameof(ContactListId))]
        public virtual ContactList ContactList { get; set; }
    }
}
