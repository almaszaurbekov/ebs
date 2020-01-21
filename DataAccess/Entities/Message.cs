using DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DataAccess.Entities
{
    public class Message : AuditableEntity<int>
    {
        public string Text { get; set; }
        public int UserSenderId { get; set; }
        public int UserReceiverId { get; set; }
        public string UserSenderEmail { get; set; }
        public string UserReceiverEmail { get; set; }
        public bool HasRead { get; set; }
        public int DialogControlId { get; set; }
    }
}
