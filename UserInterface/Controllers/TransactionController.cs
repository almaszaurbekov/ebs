using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Services.BusinessService;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserInterface.ViewModels;

namespace UserInterface.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        #region Initialize

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

        #endregion

        /// <summary>
        /// Список транзакции пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        public async Task<IActionResult> Index(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var transactions = await bookBusinessService.GetBookTransactionsByBorrowerId(id);
            var transactionsVM = mapper.Map<List<BookTransaction>, List<BookTransactionViewModel>>(transactions);
            var user = await this.userBusinessService.GetUserById(id);

            if(user == null)
            {
                return NotFound();
            }

            ViewBag.Email = user.Email;
            ViewBag.Id = user.Id;

            return View(transactionsVM);
        }

        /// <summary>
        /// Запрос на одолжение книги
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        [HttpGet]
        public async Task<IActionResult> Borrow(int id)
        {
            var book = await bookBusinessService.GetBookById(id, false);
            var currentUser = await userBusinessService.GetUserByEmail(User.Identity.Name);
            var transactions = await bookBusinessService.GetBookTransactionsByBookId(id);
            var transactionsVM = mapper.Map<List<BookTransaction>, List<BookTransactionViewModel>>(transactions);
            ViewData["Transactions"] = transactionsVM;
            ViewData["Title"] = book.Title;

            if (book.UserId == currentUser.Id)
            {
                return NotFound();
            }

            var transaction = new BookTransactionViewModel()
            {
                Id = Guid.NewGuid().ToString(),
                BorrowerId = currentUser.Id,
                OwnerId = book.UserId,
                BookId = id,
                BorrowStartDate = DateTime.Now,
                BorrowEndDate = DateTime.Now
            };

            return View(transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Borrow(string id, BookTransactionViewModel model)
        {
            if(id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var start = model.BorrowStartDate;
                    var end = model.BorrowEndDate;
                    var difference = (end - start).Days;
                    const int maxDays = 7;
                    const int minDays = 1;
                    var now = DateTime.Now.Date;
                    if((start.Date >= now && now <= end.Date) && 
                        (minDays <= difference && difference <= maxDays))
                    {
                        if(await bookBusinessService.IsThisBookFree(model.BookId, start, end))
                        {
                            var entity = mapper.Map<BookTransactionViewModel, BookTransaction>(model);
                            entity.CreatedDate = DateTime.Now;
                            entity.OwnerAgreed = -1;
                            entity.IsSuccess = -1;
                            
                            await bookBusinessService.CreateTransaction(entity);

                            return RedirectToAction("Index", new { id = entity.BorrowerId });
                        }
                        else
                        {
                            ModelState.AddModelError("", "Книга в это время занята, выберите другое время");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Бронировать книгу можно, начиная либо с текущей даты, либо с любой даты не больше недели.");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            var transactions = await bookBusinessService.GetBookTransactionsByBookId(model.BookId);
            var transactionsVM = mapper.Map<List<BookTransaction>, List<BookTransactionViewModel>>(transactions);
            ViewBag.Transactions = transactionsVM;
            return View(model);
        }

        /// <summary>
        /// Страница с запросами на одолжение
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        [HttpGet]
        public async Task<IActionResult> Requests()
        {
            var user = await userBusinessService.GetUserByEmail(User.Identity.Name);

            var transactions = await bookBusinessService.GetBookTransactionsByOwnerId(user.Id);
            foreach(var transaction in transactions)
            {
                transaction.OwnerHasSeen = true;
                await bookBusinessService.UpdateBookTransaction(transaction);
            }

            var requestsVM = mapper.Map<List<BookTransaction>, List<BookTransactionViewModel>>(transactions);
            return View(requestsVM.Where(s => s.OwnerAgreed == -1).ToList());
        }
    }
}