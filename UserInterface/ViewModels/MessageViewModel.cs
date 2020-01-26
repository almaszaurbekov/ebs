using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.ViewModels
{
    public class MessageViewModel
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
