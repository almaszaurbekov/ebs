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
    public interface IMessageService : IService<Message> { }

    public class MessageService : EntityService<Message>, IMessageService
    {
        public MessageService(EbsContext context) : base(context) { }


    }
}