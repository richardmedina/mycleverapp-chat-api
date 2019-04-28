using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyCleverApp.Chat.Model.Entities
{
    [Table(nameof(ContactInfo))]
    public class ContactInfo : EntityBase
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string DisplayImage { get; set; }
        public virtual List<ContactListContact> ContactListContact { get; set; }
    }
}
