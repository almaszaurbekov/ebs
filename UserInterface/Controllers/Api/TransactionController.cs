using AutoMapper;
using BusinessLogic.Services.BusinessService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.Controllers.Api
{
    public class TransactionController : EbsApiController
    {
        public TransactionController(IBookBusinessService bookBusinessService,
           IMapper mapper, IWebHostEnvironment hostEnvironment) : base(bookBusinessService, mapper, hostEnvironment)
        { }

        /// <summary>
        /// Запрос на успешную транзакцию
        /// </summary>
        /// <param name="id">Идентификатор транзакции</param>
        [HttpGet("transactions/accept")]
        public async Task<int> TransactionAccept(string id)
        {
            return await bookBusinessService.BookTransactionOwnerAgreed(id, true);
        }

        /// <summary>
        /// Запрос на отмену транзакции
        /// </summary>
        /// <param name="id">Идентификатор транзакции</param>
        [HttpGet("transactions/cancel")]
        public async Task<int> TransactionCancel(string id)
        {
            return await bookBusinessService.BookTransactionOwnerAgreed(id, false);
        }
    }
}
