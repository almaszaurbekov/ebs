using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Services.BusinessService;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using UserInterface.ViewModels;

namespace UserInterface.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IBookBusinessService bookBusinessService;
        private readonly IUserBusinessService userBusinessService;
        private readonly IMapper mapper;
        public TransactionController(IBookBusinessService bookBusinessService,
            IMapper mapper, IUserBusinessService userBusinessService)
        {
            this.bookBusinessService = bookBusinessService;
            this.userBusinessService = userBusinessService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(int? userId)
        {
            if(userId == null)
            {
                return NotFound();
            }

            var transactions = await bookBusinessService.GetBookTransactionsByUserId(userId);
            var transactionsVM = mapper.Map<List<BookTransaction>, List<BookTransactionViewModel>>(transactions);
            var user = await this.userBusinessService.GetUserById(userId);

            ViewBag.Email = user.Email;

            return View(transactionsVM);
        }
    }
}