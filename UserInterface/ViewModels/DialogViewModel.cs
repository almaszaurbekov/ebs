using BusinessLogic.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.ViewModels
{
    public class DialogViewModel
    {
        public int Id { get; set; }
        public List<MessageDto> Messages { get; set; }
        public string LastMessage { get; set; }
        public DateTime LastMessageDate { get; set; }
        public int FirstInterlocutorId { get; set; }
        public string FirstInterlocutorEmail { get; set; }
        public int SecondInterlocutorId { get; set; }
        public string SecondInterlocutorEmail { get; set; }

        public DialogViewModel()
        {
            Messages = new List<MessageDto>();
        }
    }
}
