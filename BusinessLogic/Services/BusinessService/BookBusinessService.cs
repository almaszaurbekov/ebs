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
        Task<Book> GetBookById(int? id, bool needComments = true);
        Task<List<Book>> GetBooksByUserId(int? id);
        Task<List<Book>> GetBooksByUserEmail(string email);
        Task<List<Book>> GetBooksByValue(string value);
        Task<int> AddBook(Book entity);
        Task<int> UpdateBook(Book entity);
    }

    public class BookBusinessService : IBookBusinessService
    {
        private readonly IMemoryCache cache;
        private readonly IBookService bookService;
        private readonly IUserService userService;
        private readonly ITransactionService transactionService;
        private readonly ICommentService commentService;

        public BookBusinessService(IMemoryCache cache, IBookService bookService,
            IUserService userService, ITransactionService transactionService,
            ICommentService commentService)
        {
            this.cache = cache;
            this.bookService = bookService;
            this.userService = userService;
            this.transactionService = transactionService;
            this.commentService = commentService;
        }

        public async Task<List<Book>> GetBooksByUserId(int? id) => await bookService.GetBooksByUserId(id);
        public async Task<List<Book>> GetBooksByUserEmail(string email)
        {
            var user = await userService.Find(s => s.Email == email);
            return await bookService.GetBooksByUserId(user.Id);
        }

        public async Task<List<Book>> GetBooksByValue(string value)
        {
            var books = await bookService.Filter(s => s.Title.Contains(value));
            if(books.Count < 5)
            {
                books.AddRange(await bookService.Filter(s => s.Author == value));
            }
            return books;
        }

        public async Task<int> AddBook(Book book)
        {
            try
            {
                await bookService.Create(book);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<Book> GetBookById(int? id, bool needComments = true)
        {
            var book = await bookService.Find(s => s.Id == id);
            if (needComments)
            {
                book.Comments = await commentService.Filter(s => s.BookId == id);
            }

            return book;
        }

        public async Task<int> UpdateBook(Book entity)
        {
            return await bookService.Update(entity);
        }
    }
}
