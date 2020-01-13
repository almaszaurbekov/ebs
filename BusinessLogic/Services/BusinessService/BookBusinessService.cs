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
        Task<List<Book>> GetBooksByUserEmail(string email);
    }

    public class BookBusinessService : IBookBusinessService
    {
        private readonly IMemoryCache cache;
        private readonly IBookService bookService;
        private readonly IUserService userService;

        public BookBusinessService(IMemoryCache cache, IBookService bookService,
            IUserService userService)
        {
            this.cache = cache;
            this.bookService = bookService;
            this.userService = userService;
        }

        public async Task<List<Book>> GetBooksByUserId(int? id) => await bookService.GetBooksByUserId(id);
        public async Task<List<Book>> GetBooksByUserEmail(string email)
        {
            var user = await userService.Find(s => s.Email == email);
            return await bookService.GetBooksByUserId(user.Id);
        }
    }
}
