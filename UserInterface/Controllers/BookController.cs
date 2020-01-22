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
            ViewBag.Search = search;
            return View();
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Id = id;
            var books = await bookBusinessService.GetBooksByUserId(id);
            var booksVM = mapper.Map<List<Book>, List<BookViewModel>>(books);

            return View(booksVM);
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
