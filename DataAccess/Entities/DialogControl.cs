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
        public int FirstInterlocutorId { get; set; }
        public string FirstInterlocutorEmail { get; set; }
        public int SecondInterlocutorId { get; set; }
        public string SecondInterlocutorEmail { get; set; }

        public DialogControl()
        {
            Messages = new List<Message>();
        }
    }
}
