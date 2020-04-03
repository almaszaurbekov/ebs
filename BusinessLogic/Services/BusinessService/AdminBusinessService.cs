using AutoMapper;
using BusinessLogic.Mappings;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.BusinessService
{
    public interface IAdminBusinessService
    {
        Task<List<ShortUserList>> GetMessagesCountByUsers();
        Task<List<ShortUserList>> GetCommentsCountByUsers();
        Task<List<ShortUserList>> GetBooksCountByUsers();
        Task<List<BookGroup>> GetBooksCountByAuthor(int minCount = 1);
        Task<List<GoodBookList>> GetBooksByCondition(bool inGoodCondition = true);
    }

    public class AdminBusinessService : IAdminBusinessService
    {
        #region Initialize

        private readonly IBookService bookService;
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly IBookTransactionService transactionService;
        private readonly ICommentService commentService;
        private readonly IBcBookService bookcityService;
        private readonly IMapper mapper;

        public AdminBusinessService(IBookService bookService, IUserService userService,
            IRoleService roleService, IBookTransactionService transactionService, 
            ICommentService commentService, IBcBookService bookcityService)
        {
            this.bookService = bookService;
            this.userService = userService;
            this.roleService = roleService;
            this.transactionService = transactionService;
            this.commentService = commentService;
            this.bookcityService = bookcityService;
            this.mapper = MapperConfig.MapperInitialize();
        }

        #endregion

        /// <summary>
        /// Get group of books by authors with a minimal count
        /// </summary>
        /// <param name="minCount">Minimum count of books</param>
        /// <returns></returns>
        public async Task<List<BookGroup>> GetBooksCountByAuthor(int minCount = 1)
        {
            var sql = $@"SELECT b.Author, COUNT(*) FROM Books AS b
                        GROUP BY b.Author
                        HAVING COUNT(*) >= {minCount}";

            return await bookService.GetBooksCountByAuthor(sql);
        }

        public async Task<List<ShortUserList>> GetBooksCountByUsers()
        {
            var sql = @"SELECT u.Id, COUNT(*) FROM Users AS u 
                        JOIN Books AS b ON u.Id = b.UserId
                        GROUP BY u.Id";
            return await userService.GetShortUserList(sql);
        }

        public async Task<List<ShortUserList>> GetMessagesCountByUsers()
        {
            var sql = @"SELECT u.Id, COUNT(*) FROM Users AS u 
                        JOIN Messages AS m ON u.Id = m.UserSenderId OR
                        u.Id = m.UserReceiverId
                        GROUP BY u.Id";
            return await userService.GetShortUserList(sql);
        }

        public async Task<List<ShortUserList>> GetCommentsCountByUsers()
        {
            var sql = @"SELECT u.Id, COUNT(*) FROM Users AS u 
                        JOIN Comments AS c ON u.Id = c.UserId
                        GROUP BY u.Id";
            return await userService.GetShortUserList(sql);
        }

        public async Task<List<GoodBookList>> GetBooksByCondition(bool inGoodCondition = true)
        {
            var sql = $@"exec GetBooksByCondition 
                        @inGoodCondition = {Convert.ToInt32(inGoodCondition)}";
            return await bookService.GetBooksByCondition(sql);
        }
    }
}