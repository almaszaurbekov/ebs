using BusinessLogic.Dto.Base;
using Common.BookTransaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Dto
{
    public class BookTransactionDto : DtoModel<Guid>
    {
        public DateTime BorrowStartDate { get; set; }
        public DateTime BorrowEndDate { get; set; }
        public BookDto Book { get; set; }
        public int BookId { get; set; }
        public int OwnerId { get; set; }
        public int BorrowerId { get; set; }
        public bool? IsSuccess { get; set; } = null;
        public bool? OwnerAgreed { get; set; } = null;
        public bool OwnerHasSeen { get; set; } = false;
        public TransactionStatus Status { get; set; } = TransactionStatus.Unknown;
        public string Comment { get; set; }
    }
}
