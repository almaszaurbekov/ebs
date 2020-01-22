using BusinessLogic.Services.Base;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace BusinessLogic.Services
{
    public interface ITransactionService : IService<Transaction> { }
    public class TransactionService : EntityService<Transaction>, ITransactionService
    {
        public TransactionService(EbsContext context) : base(context) { }
    }
}
