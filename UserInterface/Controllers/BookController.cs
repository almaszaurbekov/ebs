using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using BusinessLogic.Services.BusinessService;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using UserInterface.ViewModels.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using UserInterface.ViewModels;

namespace UserInterface.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        #region Initialize

        private readonly IUserBusinessService userBusinessService;
        private readonly IBookBusinessService bookBusinessService;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IMapper mapper;

        public BookController(IBookBusinessService bookBusinessService, IMapper mapper,
            IWebHostEnvironment hostEnvironment, IUserBusinessService userBusinessService)
        {
            this.bookBusinessService = bookBusinessService;
            this.userBusinessService = userBusinessService;
            this.hostEnvironment = hostEnvironment;
            this.mapper = mapper;
        }

        #endregion

        /// <summary>
        /// Страница с поисковиком
        /// </summary>
        /// <param name="search">Объект поиска</param>
        public async Task<IActionResult> Index(string search)
        {
            var books = await bookBusinessService.GetBooksBySearchValue(search);
            var booksVM = mapper.Map<List<Book>, List<BookViewModel>>(books);
            ViewBag.Search = search;
            return View(booksVM);
        }

        /// <summary>
        /// Детальная информация о книге
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await bookBusinessService.GetBookById(id);
            var bookVM = mapper.Map<Book, BookViewModel>(book);
            var user = await userBusinessService.GetUserById(book.UserId);
            ViewBag.IsCurrentUser = user.Email == User.Identity.Name;
            return View(bookVM);
        }

        /// <summary>
        /// Получить список книг по пользователю
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        public async Task<IActionResult> ByUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await userBusinessService.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }

            var books = await bookBusinessService.GetBooksByUserId(id);
            var booksVM = mapper.Map<List<Book>, List<BookViewModel>>(books.OrderBy(s => s.CreatedDate).ToList());
            ViewBag.Email = user.Email;
            return View(booksVM);
        }


        /// <summary>
        /// Создать книгу
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await userBusinessService.GetUserByEmail(User.Identity.Name);
            if(user == null)
            {
                return NotFound();
            }

            ViewBag.UserId = user.Id;
            return View(new BookViewModel());
        }

        /// <summary>
        /// Редактировать книгу
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var book = await bookBusinessService.GetBookById(id, false);

            if(book == null)
            {
                return NotFound();
            }

            var user = await userBusinessService.GetUserById(book.UserId);
            if(user.Email != User.Identity.Name)
            {
                return RedirectToAction("Index", "User");
            }

            var bookVM = mapper.Map<Book, BookViewModel>(book);
            return View(bookVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = await bookBusinessService.GetBookById(model.Id, false);
                    entity = mapper.Map(model, entity);

                    if (model.Image != null)
                        entity.ImageSource = CreateFile(model.Image.FileName, model.Image);

                    if (model.RemoveImage)
                        entity.ImageSource = null;

                    await bookBusinessService.UpdateBook(entity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await BookExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = model.Id });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await bookBusinessService.GetBookById(id, false);

            if (book == null)
            {
                return NotFound();
            }

            var user = await userBusinessService.GetUserById(book.UserId);
            if (user.Email != User.Identity.Name)
            {
                return RedirectToAction("Index", "User");
            }

            var bookVM = mapper.Map<Book, BookViewModel>(book);
            return View(bookVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, BookViewModel model)
        {
            if(id != model.Id)
            {
                return NotFound();
            }

            var entity = await bookBusinessService.GetBookById(model.Id, false);

            if(entity.User.Email != User.Identity.Name)
            {
                return NotFound();
            }

            await bookBusinessService.DeleteBook(entity);

            return RedirectToAction("ByUser", new { id = entity.User.Id });
        }

        /// <summary>
        /// Проверка на наличие книги
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns></returns>
        private async Task<bool> BookExists(int id)
        {
            return await bookBusinessService.GetBookById(id) != null;
        }

        /// <summary>
        /// Функция по созданию файла в wwwroot/img
        /// </summary>
        /// <param name="imgfileName">Имя файла, отправленного пользователем</param>
        /// <param name="image">HtppRequest фотографии</param>
        private string CreateFile(string imgfileName, IFormFile image)
        {
            string fileName = null;
            string folder = Path.Combine(hostEnvironment.WebRootPath, "img");
            fileName = Guid.NewGuid().ToString() + "_" + imgfileName;
            string filepath = Path.Combine(folder, fileName);
            image.CopyTo(new FileStream(filepath, FileMode.Create));
            return fileName;
        }
    }
}
