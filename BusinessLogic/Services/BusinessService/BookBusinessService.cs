using DataAccess.Entities;
using Microsoft.Extensions.Caching.Memory;
using Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.BusinessService
{
    public interface IBookBusinessService
    {
        Task<List<Book>> GetBooksByUserId(int? id);
    }

    public class BookBusinessService : IBookBusinessService
    {
        private readonly IMemoryCache cache;
        private readonly IBookService bookService;

        public BookBusinessService(IMemoryCache cache, IBookService bookService)
        {
            this.cache = cache;
            this.bookService = bookService;
        }

        public async Task<List<Book>> GetBooksByUserId(int? id) => await bookService.GetBooksByUserId(id);
    }
}
