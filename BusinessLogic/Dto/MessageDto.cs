using BusinessLogic.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Dto
{
    public class MessageDto : DtoModel<int>
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
