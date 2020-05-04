using BusinessLogic.Loggers.Base;
using Common;
using DataAccess;
using DataAccess.Entities;
using System.Threading.Tasks;

namespace BusinessLogic.Loggers
{
    public interface IBookOperationsLogger
    {
        Task AddLog(string message, EbsLoggerLevel level);
        Task AddLog(string message, EbsLoggerLevel level, int userId);
        Task AddLog(string message, EbsLoggerLevel level, int userId, int bookId);
        Task AddLog(string message, EbsLoggerLevel level, int userId, int bookId, string userEmail);
    }

    public class BookOperationsLogger : EntityLogger<BookOperationsLog>, IBookOperationsLogger
    {
        private readonly string DefaultEmailValue = "Пусто";

        public BookOperationsLogger(EbsContext context) : base(context) { }

        public async Task AddLog(string message, EbsLoggerLevel level)
        {
            var log = new BookOperationsLog()
            {
                Level = level,
                LevelText = level.ToString(),
                UserEmail = DefaultEmailValue,
                Message = message
            };

            var entry = DbSet.Add(log);
            await context.SaveChangesAsync();
        }

        public async Task AddLog(string message, EbsLoggerLevel level, int userId)
        {
            var log = new BookOperationsLog()
            {
                Level = level,
                LevelText = level.ToString(),
                UserId = userId,
                UserEmail = DefaultEmailValue,
                Message = message
            };

            var entry = DbSet.Add(log);
            await context.SaveChangesAsync();
        }

        public async Task AddLog(string message, EbsLoggerLevel level, int userId, int bookId)
        {
            var log = new BookOperationsLog()
            {
                Level = level,
                LevelText = level.ToString(),
                UserId = userId,
                BookId = bookId,
                UserEmail = DefaultEmailValue,
                Message = message
            };

            var entry = DbSet.Add(log);
            await context.SaveChangesAsync();
        }

        public async Task AddLog(string message, EbsLoggerLevel level, int userId, int bookId, string userEmail)
        {
            var log = new BookOperationsLog()
            {
                Level = level,
                LevelText = level.ToString(),
                UserId = userId,
                BookId = bookId,
                UserEmail = userEmail,
                Message = message
            };

            var entry = DbSet.Add(log);
            await context.SaveChangesAsync();
        }
    }
}
