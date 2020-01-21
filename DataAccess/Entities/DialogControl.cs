using DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class DialogControl : AuditableEntity<int>
    {
        public List<Message> Messages { get; set; }
        public string LastMessage { get; set; }
        public DateTime LastMessageDate { get; set; }
        public DialogControl()
        {
            Messages = new List<Message>();
        }
    }
}
