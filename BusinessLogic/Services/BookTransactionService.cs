using BusinessLogic.Services.Base;
using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace BusinessLogic.Services
{
    public interface IBookTransactionService : IService<BookTransaction> { }
    public class BookTransactionService : EntityService<BookTransaction>, IBookTransactionService
    {
        public BookTransactionService(EbsContext context) : base(context) { }
    }
}
