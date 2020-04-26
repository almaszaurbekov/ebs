using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Mappings;
using DataAccess.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Services.BusinessService
{
    public interface IBookBusinessService
    {
        Task<BookDto> GetBookById(int? id, bool needComments = true);
        Task<List<BookDto>> GetBooks();
        Task<List<BookDto>> GetBooksByUserId(int? id);
        Task<List<BookDto>> GetBooksByUserEmail(string email);
        Task<int> AddBook(BookDto dtoModel);
        Task<int> UpdateBook(BookDto dtoModel);
        Task<List<BookTransactionDto>> GetBookTransactionsByOwnerId(int? id);
        Task<List<BookTransactionDto>> GetBookTransactionsByBorrowerId(int? id);
        Task<List<BookTransactionDto>> GetBookTransactionsByUserId(int? id);
        Task<BookTransactionDto> GetBookTransactionById(Guid? id);
        Task<List<BookDto>> GetBooksBySearchValue(string value);
        Task<int> CreateTransaction(BookTransactionDto dtoModel);
        Task<bool> IsThisBookFree(int bookId, DateTime start, DateTime end);
        Task<int> UpdateBookTransaction(BookTransactionDto dtoModel);
        Task<List<BookTransactionDto>> GetBookTransactionsByBookId(int id);
        Task<int> GetCountOfBookRequests(int userId);
        Task<int> DeleteBook(BookDto dtoModel);
        Task<List<BcBookDto>> GetBooksByValue(string value);
        Task<BcBookDto> GetBcBook(int id);
        Task<int> BookTransactionOwnerAgreed(string id, bool accept);
    }

    public class BookBusinessService : IBookBusinessService
    {
        #region Initialize

        private readonly IMemoryCache cache;
        private readonly IBookService bookService;
        private readonly IUserService userService;
        private readonly IBookTransactionService transactionService;
        private readonly ICommentService commentService;
        private readonly IBcBookService bookcityService;
        private readonly IMapper mapper;

        public BookBusinessService(IMemoryCache cache, IBookService bookService,
            IUserService userService, IBookTransactionService transactionService,
            ICommentService commentService, IBcBookService bookcityService)
        {
            this.cache = cache;
            this.bookService = bookService;
            this.userService = userService;
            this.transactionService = transactionService;
            this.commentService = commentService;
            this.bookcityService = bookcityService;
            this.mapper = MapperConfig.MapperInitialize();
        }

        #endregion

        public async Task<List<BookDto>> GetBooksByUserId(int? id)
        {
            var books = await bookService.GetBooksByUserId(id);
            return mapper.Map<List<Book>, List<BookDto>>(books);
        }
        public async Task<List<BookDto>> GetBooksByUserEmail(string email)
        {
            var user = await userService.Find(s => s.Email == email);
            var books = await bookService.GetBooksByUserId(user.Id);
            return mapper.Map<List<Book>, List<BookDto>>(books);
        }

        public async Task<int> AddBook(BookDto book)
        {
            try
            {
                var entity = mapper.Map<BookDto, Book>(book);
                await bookService.Create(entity);
                return book.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<BookDto> GetBookById(int? id, bool needComments = true)
        {
            var book = await bookService.Find(s => s.Id == id);
            if (needComments)
            {
                book.Comments = await commentService.Filter(s => s.BookId == id);
            }

            return mapper.Map<Book, BookDto>(book);
        }

        public async Task<int> UpdateBook(BookDto dtoModel)
        {
            var entity = mapper.Map<BookDto, Book>(dtoModel);
            return await bookService.Update(entity);
        }

        public async Task<List<BookTransactionDto>> GetBookTransactionsByUserId(int? id)
        {
            var trans = await transactionService.Filter(s => s.OwnerId == id || s.BorrowerId == id);
            return mapper.Map<List<BookTransaction>, List<BookTransactionDto>>(trans);
        }

        public async Task<List<BookTransactionDto>> GetBookTransactionsByBorrowerId(int? id)
        {
            var trans = await transactionService.Filter(s => s.BorrowerId == id);
            return mapper.Map<List<BookTransaction>, List<BookTransactionDto>>(trans);
        }

        public async Task<List<BookTransactionDto>> GetBookTransactionsByOwnerId(int? id)
        {
            var trans = await transactionService.Filter(s => s.OwnerId == id && s.OwnerAgreed == -1);
            foreach(var tran in trans)
            {
                tran.OwnerHasSeen = true;
                await transactionService.Update(tran);
            }
            return mapper.Map<List<BookTransaction>, List<BookTransactionDto>>(trans);
        }

        public async Task<BookTransactionDto> GetBookTransactionById(Guid? id)
        {
            var tran = await transactionService.Find(s => s.Id == id);
            return mapper.Map<BookTransaction, BookTransactionDto>(tran);
        }

        public async Task<List<BookDto>> GetBooksBySearchValue(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    var books = await bookService.GetBooksSortedByDate();
                    return mapper.Map<List<Book>, List<BookDto>>(
                        books.OrderByDescending(s => s.CreatedDate).ToList());
                }
                else
                {
                    var books = await bookService.Filter(s => s.Title.Contains(value));
                    if (books.Count < 5)
                        books.AddRange(await bookService.Filter(s => s.Author.Contains(value)));

                    return mapper.Map<List<Book>, List<BookDto>>(
                        books.OrderByDescending(s => s.CreatedDate).ToList());
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<int> CreateTransaction(BookTransactionDto modelDto)
        {
            try
            {
                var entity = mapper.Map<BookTransactionDto, BookTransaction>(modelDto);
                await transactionService.Create(entity);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> IsThisBookFree(int bookId, DateTime start, DateTime end)
        {
            return await transactionService.IsThisBookFree(bookId, start, end);
        }

        public async Task<int> UpdateBookTransaction(BookTransactionDto modelDto)
        {
            var entity = mapper.Map<BookTransactionDto, BookTransaction>(modelDto);
            return await transactionService.Update(entity);
        }

        public async Task<List<BookTransactionDto>> GetBookTransactionsByBookId(int id)
        {
            var trans = await transactionService.Filter(s => s.BookId == id);
            return mapper.Map<List<BookTransaction>, List<BookTransactionDto>>(trans);
        }

        public async Task<int> GetCountOfBookRequests(int userId)
        {
            var transactions = await transactionService.Filter(s => s.OwnerId == userId && !s.OwnerHasSeen);
            return transactions.Count;
        }

        public async Task<int> DeleteBook(BookDto modelDto)
        {
            var entity = mapper.Map<BookDto, Book>(modelDto);
            return await bookService.Delete(entity);
        }

        public async Task<List<BcBookDto>> GetBooksByValue(string value)
        {
            var books = await bookcityService.GetBooksByValue(value);
            return mapper.Map<List<BcBook>, List<BcBookDto>>(books);
        }

        public async Task<BcBookDto> GetBcBook(int id)
        {
            var book = await bookcityService.Find(s => s.Id == id);
            return mapper.Map<BcBook, BcBookDto>(book);
        }

        public async Task<List<BookDto>> GetBooks()
        {
            var books = await bookService.GetAll();
            return mapper.Map<List<Book>, List<BookDto>>(books);
        }

        public async Task<int> BookTransactionOwnerAgreed(string id, bool accept)
        {
            var transaction = await transactionService.Find(s => s.Id.ToString() == id);
            if (accept)
                transaction.OwnerAgreed = 1;
            else
            {
                transaction.OwnerAgreed = 0;
                transaction.IsSuccess = 0;
            }
            return await transactionService.Update(transaction);
        }
    }
}