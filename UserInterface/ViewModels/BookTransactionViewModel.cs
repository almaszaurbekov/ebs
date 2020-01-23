using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.ViewModels
{
    public class BookTransactionViewModel
    {
        public Guid Id { get; set; }
        public DateTime BorrowStartDate { get; set; }
        public DateTime BorrowEndDate { get; set; }
        public int BookId { get; set; }
        public int OwnerId { get; set; }
        public int BorrowerId { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}