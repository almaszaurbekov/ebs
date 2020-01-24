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

namespace BusinessLogic.Services
{
    public interface IBookService : IService<Book>
    {
        Task<List<Book>> GetBooksByUserId(int? id);
        Task<List<Book>> GetBooksByDate();
    }

    public class BookService : EntityService<Book>, IBookService
    {
        public BookService(EbsContext context) : base(context) { }

        public async Task<List<Book>> GetBooksByUserId(int? id)
        {
            return await DbSet.Where(s => s.UserId == id).ToListAsync();
        }

        public override async Task<List<Book>> Filter(Expression<Func<Book, bool>> predicate)
        {
            return await DbSet
                .Include(u => u.User)
                .Where(predicate)
                .ToListAsync();
        }

        public override async Task<Book> Find(Expression<Func<Book, bool>> predicate)
        {
            return await DbSet
                .Include(u => u.User)
                .Where(predicate)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Book>> GetBooksByDate()
        {
            return await DbSet
                .Include(u => u.User)
                .OrderByDescending(s => s.CreatedDate)
                .ToListAsync();
        }
    }
}
