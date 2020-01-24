using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.Entities;
using BusinessLogic.Services.BusinessService;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using UserInterface.ViewModels.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace UserInterface.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
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

        // Поисковик
        public async Task<IActionResult> Index(string search)
        {
            var books = await bookBusinessService.GetBooksBySearchValue(search);
            var booksVM = mapper.Map<List<Book>, List<BookViewModel>>(books);
            ViewBag.Search = search;
            return View(booksVM);
        }

        // GET: Books/Details/5
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

        // ELibrary
        public async Task<IActionResult> ByUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var books = await bookBusinessService.GetBooksByUserId(id);
            var booksVM = mapper.Map<List<Book>, List<BookViewModel>>(books.OrderBy(s => s.CreatedDate).ToList());
            var user = await userBusinessService.GetUserById(id);
            ViewBag.Email = user.Email;
            ViewBag.IsCurrentUser = user.Id == id;
            return View(booksVM);
        }

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

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var book = await bookBusinessService.GetBookById(id, false);
            var bookVM = mapper.Map<Book, BookViewModel>(book);
            var user = await userBusinessService.GetUserById(book.UserId);
            if(user.Email != User.Identity.Name)
            {
                return RedirectToAction("Index", "User");
            }

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

        private async Task<bool> BookExists(int id)
        {
            return await bookBusinessService.GetBookById(id) != null;
        }

        /// <summary>
        /// Функция по созданию файла в wwwroot/images
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

        //// POST: Books/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Title,Description,Author,Rate,ImageSource,UserId,Id")] Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(book);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", book.UserId);
        //    return View(book);
        //}

        //// GET: Books/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var book = await _context.Books.FindAsync(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", book.UserId);
        //    return View(book);
        //}

        //// POST: Books/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Title,Description,Author,Rate,ImageSource,UserId,Id")] Book book)
        //{
        //    if (id != book.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(book);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BookExists(book.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", book.UserId);
        //    return View(book);
        //}

        //// GET: Books/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var book = await _context.Books
        //        .Include(b => b.User)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(book);
        //}

        //// POST: Books/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var book = await _context.Books.FindAsync(id);
        //    _context.Books.Remove(book);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BookExists(int id)
        //{
        //    return _context.Books.Any(e => e.Id == id);
        //}
    }
}
