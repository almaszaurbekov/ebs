using DataAccess.Entities;
using Microsoft.Extensions.Caching.Memory;
using Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.BusinessService
{
    public interface IBookBusinessService
    {

    }

    public class BookBusinessService : IBookBusinessService
    {
        private readonly IMemoryCache cache;

        public BookBusinessService(IMemoryCache cache)
        {
            this.cache = cache;
        }

        
    }
}
