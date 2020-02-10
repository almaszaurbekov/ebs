using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public double Rate { get; set; }
        public string ImageSource { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<BookTransactionDto> BookTransactions { get; set; }
        public bool IsBorrowed { get; set; } = false;
        public bool InGoodCondition { get; set; } = true;
        public bool IsPainted { get; set; } = false;
        public DateTime CreatedDate { get; set; }

        public BookDto()
        {
            Comments = new List<CommentDto>();
            BookTransactions = new List<BookTransactionDto>();
        }
    }
}
