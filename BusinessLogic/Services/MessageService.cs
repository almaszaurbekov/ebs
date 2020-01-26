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
        Task<List<int>> GetDialogIds(string email);
        Task<List<Message>> GetMessagesByUsers(int senderId, int receiverId);
    }

    public class MessageService : EntityService<Message>, IMessageService
    {
        public MessageService(EbsContext context) : base(context) { }

        public async Task<List<int>> GetDialogIds(string email)
        {
            return await DbSet.Where(s => s.UserReceiverEmail == email || s.UserSenderEmail == email)
                .Select(m => m.DialogControlId).ToListAsync();
        }

        public async Task<List<Message>> GetMessagesByUsers(int senderId, int receiverId)
        {
            return await DbSet.Where(s => s.UserReceiverId == receiverId && s.UserSenderId == senderId).ToListAsync();
        }
    }
}