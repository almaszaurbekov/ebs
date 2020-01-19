using BusinessLogic.Services.Base;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IBcBookService : IService<BcBook>
    {
        Task<List<BcBook>> GetBooksByValue(string value);
    }
    public class BcBookService : EntityService<BcBook>, IBcBookService
    {
        public BcBookService(EbsContext context) : base(context) { }
        public async Task<List<BcBook>> GetBooksByValue(string value)
        {
            return await DbSet.Where(s => s.Title.Contains(value) || 
                s.Author.Contains(value)).ToListAsync();
        }
    }
}