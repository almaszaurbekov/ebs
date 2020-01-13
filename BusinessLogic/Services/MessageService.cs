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
        //Task<List<Message>> GetMessagesByUsers(int senderId, int receiverId);
    }

    public class MessageService : EntityService<Message>, IMessageService
    {
        public MessageService(EbsContext context) : base(context) { }

        //public async Task<List<Message>> GetMessagesByUsers(int senderId, int receiverId)
        //{
        //    return await DbSet.Where(s => s.UserSenderId == senderId && s.UserReceiverId == receiverId).ToListAsync();
        //}
    }
}