using BusinessLogic.Loggers.Base;
using Common;
using DataAccess;
using DataAccess.Entities;
using System.Threading.Tasks;

namespace BusinessLogic.Loggers
{
    public interface IBookOperationsLogger
    {
        Task AddLog(string message, int bookId, int userId, EbsLoggerLevel level);
        Task AddLog(string message, EbsLoggerLevel level);
    }

    public class BookOperationsLogger : EntityLogger<BookOperationsLog>, IBookOperationsLogger
    {
        public BookOperationsLogger(EbsContext context) : base(context) { }

        public async Task AddLog(string message, int bookId, int userId, EbsLoggerLevel level)
        {
            var log = new BookOperationsLog()
            {
                Level = level,
                LevelText = level.ToString(),
                UserId = userId,
                BookId = bookId,
                Message = message
            };

            var entry = DbSet.Add(log);
            await context.SaveChangesAsync();
        }

        public async Task AddLog(string message, EbsLoggerLevel level)
        {
            var log = new BookOperationsLog()
            {
                Level = level,
                LevelText = level.ToString(),
                Message = message
            };

            var entry = DbSet.Add(log);
            await context.SaveChangesAsync();
        }
    }
}
