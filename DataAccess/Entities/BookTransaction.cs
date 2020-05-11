using Common.BookTransaction;
using DataAccess.Entities.Base;
using System;

namespace DataAccess.Entities
{
    public class BookTransaction : AuditableEntity<Guid>
    {
        /// <summary>
        /// Beginning of borrow
        /// </summary>
        public DateTime BorrowStartDate { get; set; }

        /// <summary>
        /// Ending of borrow
        /// </summary>
        public DateTime BorrowEndDate { get; set; }

        /// <summary>
        /// Borrowing book
        /// </summary>
        public Book Book { get; set; }

        /// <summary>
        /// Book's Identifier
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Book Owner Identifier
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Book Borrower Identifier
        /// </summary>
        public int BorrowerId { get; set; }

        /// <summary>
        /// The owner saw a warning that someone wants to borrow his book
        /// </summary>
        public bool OwnerHasSeen { get; set; }

        /// <summary>
        /// The owner consent for borrow
        /// </summary>
        public bool? OwnerAgreed { get; set; }

        /// <summary>
        /// Did the deal go well
        /// </summary>
        public bool? IsSuccess { get; set; }

        /// <summary>
        /// Deal status
        /// </summary>
        public TransactionStatus Status { get; set; }

        /// <summary>
        /// Any comment from the owner
        /// </summary>
        public string Comment { get; set; }
    }
}