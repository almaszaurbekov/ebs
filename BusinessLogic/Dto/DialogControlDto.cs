using BusinessLogic.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Dto
{
    public class DialogControlDto : DtoModel<int>
    {
        public List<MessageDto> Messages { get; set; }
        public string LastMessage { get; set; }
        public DateTime LastMessageDate { get; set; }
        public int FirstInterlocutorId { get; set; }
        public string FirstInterlocutorEmail { get; set; }
        public int SecondInterlocutorId { get; set; }
        public string SecondInterlocutorEmail { get; set; }

        public DialogControlDto()
        {
            Messages = new List<MessageDto>();
        }
    }
}
