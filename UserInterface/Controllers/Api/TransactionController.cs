using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Services.BusinessService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInterface.ViewModels;

namespace UserInterface.Controllers.Api
{
    public class TransactionController : EbsApiController
    {
        public TransactionController(IBookBusinessService bookBusinessService, 
            IUserBusinessService userBusinessService,
           IMapper mapper, IWebHostEnvironment hostEnvironment) 
            : base(bookBusinessService, mapper, hostEnvironment, userBusinessService)
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


        /// <summary>
        /// Список транзакции по пользователю
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        [HttpGet("transactions/user/{id}")]
        public async Task<IActionResult> GetTransactionsByUserId(int id)
        {
            var transactions = await bookBusinessService.GetBookTransactionsByUserId(id);
            var transactionsVM = mapper.Map<List<BookTransactionDto>, 
                List<BookTransactionViewModel>>(transactions);
            return Ok(new { data = transactionsVM });
        }
    }
}
