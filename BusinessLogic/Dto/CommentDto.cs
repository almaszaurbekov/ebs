using BusinessLogic.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Dto
{
    public class CommentDto : DtoModel<int>
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
