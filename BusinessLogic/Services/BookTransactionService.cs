using BusinessLogic.Services.Base;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessLogic.Services
{
    public interface IBookTransactionService : IService<BookTransaction>
    {
        Task<bool> IsThisBookFree(int bookId, DateTime start, DateTime end);
    }

    public class BookTransactionService : EntityService<BookTransaction>, IBookTransactionService
    {
        public BookTransactionService(EbsContext context) : base(context) { }

        public async Task<bool> IsThisBookFree(int bookId, DateTime start, DateTime end)
        {
            var transactions = await DbSet.Where(s => s.BookId == bookId).ToListAsync();
            foreach(var tr in transactions)
            {
                if(IsDateInRange(start, end, tr.BorrowStartDate) || 
                    IsDateInRange(start, end, tr.BorrowEndDate) && tr.OwnerAgreed)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsDateInRange(DateTime start, DateTime end, DateTime date)
        {
            return start.Date >= date.Date && date.Date <= end.Date;
        }
    }
}
