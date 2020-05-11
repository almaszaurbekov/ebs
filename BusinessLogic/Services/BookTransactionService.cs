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

            // We check only those transactions where the owner agreed to borrow the book
            var ownerAgreedTransactions = transactions.Where(s => s.OwnerAgreed == true).ToList();
            
            foreach(var transaction in ownerAgreedTransactions)
            {
                if(transaction.BorrowEndDate > start)
                {
                    if (transaction.BorrowStartDate <= start || transaction.BorrowStartDate <= end)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
