using DataAccess.Entities.Base;
using System;

namespace DataAccess.Entities
{
    public class BookTransaction : AuditableEntity<Guid>
    {
        public DateTime BorrowStartDate { get; set; }
        public DateTime BorrowEndDate { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public int OwnerId { get; set; }
        public int BorrowerId { get; set; }
        public bool IsSuccess { get; set; } = false;
        public bool OwnerHasSeen { get; set; } = false;
        public bool OwnerAgreed { get; set; } = false;
    }
}