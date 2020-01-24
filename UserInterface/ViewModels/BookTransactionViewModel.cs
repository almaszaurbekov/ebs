using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.ViewModels
{
    public class BookTransactionViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public DateTime BorrowStartDate { get; set; }
        [Required]
        public DateTime BorrowEndDate { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public int BorrowerId { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}