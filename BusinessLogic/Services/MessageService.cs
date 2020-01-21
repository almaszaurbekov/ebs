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
    public interface IMessageService : IService<Message>
    {
        Task<List<Message>> GetMessagesByUserId(int userId);
        Task<List<Message>> GetMessagesByUserEmail(string email);
    }

    public class MessageService : EntityService<Message>, IMessageService
    {
        public MessageService(EbsContext context) : base(context) { }

        public async Task<List<Message>> GetMessagesByUserId(int userId)
        {
            return await DbSet.Where(s => s.UserSenderId == userId || s.UserReceiverId == userId).OrderBy(m => m.CreatedDate).ToListAsync();
        }

        public async Task<List<Message>> GetMessagesByUserEmail(string email)
        {
            return await DbSet.Where(s => s.UserSenderEmail == email || s.UserReceiverEmail == email).OrderBy(m => m.CreatedDate).ToListAsync();
        }
    }
}