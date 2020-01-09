using BusinessLogic.Services.Base;
using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    public interface IBookService : IService<Book> { }

    public class BookService : EntityService<Book>, IBookService
    {
        public BookService(EbsContext context) : base(context) { }
    }
}
