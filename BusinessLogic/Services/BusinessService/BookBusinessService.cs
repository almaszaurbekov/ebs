using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Loggers;
using BusinessLogic.Mappings;
using Common;
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
        Task<BookDto> GetBookById(int? id, int? userId, bool needComments = true);
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
        Task ViewBook(int bookId, int userId);
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
        private readonly IBookOperationsLogger _logger;

        public BookBusinessService(IMemoryCache cache, IBookService bookService,
            IUserService userService, IBookTransactionService transactionService,
            ICommentService commentService, IBcBookService bookcityService,
            IBookOperationsLogger logger)
        {
            this.cache = cache;
            this.bookService = bookService;
            this.userService = userService;
            this.transactionService = transactionService;
            this.commentService = commentService;
            this.bookcityService = bookcityService;
            _logger = logger;
            this.mapper = MapperConfig.MapperInitialize();
        }

        #endregion

        public async Task<List<BookDto>> GetBooksByUserId(int? id)
        {
            try
            {
                await _logger.AddLog($"Pulling a books from a database", EbsLoggerLevel.Info);

                if (id == null)
                {
                    await _logger.AddLog("It is not possible to pull out a list of books by user id, without the id itself", EbsLoggerLevel.Error);
                    throw new Exception();
                }

                var books = await bookService.GetBooksByUserId(id);

                await _logger.AddLog($"Got books by user ID: {id}", EbsLoggerLevel.Debug, id.ToString());

                return mapper.Map<List<Book>, List<BookDto>>(books);
            }
            catch (Exception ex)
            {
                await _logger.AddLog(ex.Message, EbsLoggerLevel.Fatal);
                throw ex;
            }
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
                entity = await bookService.Create(entity);

                await _logger.AddLog($"Book ID: {entity.Id} was created successfully by User ID: {entity.UserId}",
                    EbsLoggerLevel.Info, entity.Id.ToString());

                return book.Id;
            }
            catch (Exception ex)
            {
                await _logger.AddLog(ex.Message, EbsLoggerLevel.Error);
                return 0;
            }
        }

        /// <summary>
        /// Получить детальную информацию о книге
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <param name="userId">Идентификатор пользователя, который смотрит книгу</param>
        /// <param name="needComments">Нужно ли отображать комменты</param>
        public async Task<BookDto> GetBookById(int? id, int? userId, bool needComments = true)
        {
            var book = await bookService.Find(s => s.Id == id);

            if (userId != null)
            {
                await ViewBook((int)id, (int)userId);
            }

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
            try
            {
                await _logger.AddLog("Removing a book from the database", EbsLoggerLevel.Warn, modelDto.Id.ToString());

                var entity = mapper.Map<BookDto, Book>(modelDto);
                var result = await bookService.Delete(entity);

                await _logger.AddLog($"Book ID: {modelDto.Id} was successfully deleted by User ID: {modelDto.UserId}",
                    EbsLoggerLevel.Debug, modelDto.Id.ToString());

                return result;
            }
            catch(Exception ex)
            {
                await _logger.AddLog(ex.Message, EbsLoggerLevel.Error, modelDto.Id.ToString());
                return 0;
            }
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

        public async Task ViewBook(int bookId, int userId) => await bookService.ViewBook(bookId, userId);
    }
}