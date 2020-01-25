using BusinessLogic.Services.Base;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public override async Task<List<BookTransaction>> GetAll()
        {
            try
            {
                var entities = await DbSet
                    .Include(s => s.Book)
                    .ToListAsync();
                return entities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<BookTransaction> Find(Expression<Func<BookTransaction, bool>> predicate)
        {
            return await DbSet
                .Include(s => s.Book)
                .Where(predicate)
                .FirstOrDefaultAsync();
        }

        public override async Task<List<BookTransaction>> Filter(Expression<Func<BookTransaction, bool>> predicate)
        {
            return await DbSet
                .Include(s => s.Book)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<bool> IsThisBookFree(int bookId, DateTime start, DateTime end)
        {
            var transactions = await DbSet.Where(s => s.BookId == bookId).ToListAsync();
            foreach(var tr in transactions)
            {
                if((IsDateInRange(start, end, tr.BorrowStartDate) || 
                    IsDateInRange(start, end, tr.BorrowEndDate)) && tr.OwnerAgreed)
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
