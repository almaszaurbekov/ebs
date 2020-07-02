using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Services.BusinessService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UserInterface.ViewModels;

namespace UserInterface.Controllers.Api
{
    public class BookController : EbsApiController
    {
        public BookController(IBookBusinessService bookBusinessService, 
            IUserBusinessService userBusinessService,
            IMapper mapper, IWebHostEnvironment hostEnvironment) 
            : base(bookBusinessService, mapper, hostEnvironment, userBusinessService)
        { }

        /// <summary>
        /// Получить список книг из внутренней БД
        /// </summary>
        /// <param name="value">Значение поисковика</param>
        [HttpGet("books/byvalue")]
        public async Task<List<BcBookDto>> BooksByValue(string value)
        {
            var books = await bookBusinessService.GetBooksByValue(value);
            return books.Take(50).ToList();
        }

        /// <summary>
        /// Запрос на автозаполнение книги из внутренней БД
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        [HttpGet("books/auto/add")]
        public async Task<int> AddAutoBook(int id)
        {
            var user = await userBusinessService.GetUserByEmail(User.Identity.Name);
            var bcbook = await bookBusinessService.GetBcBook(id);
            var book = mapper.Map<BcBookDto, BookDto>(bcbook);
            book.Id = 0;
            book.UserId = user.Id;
            return await bookBusinessService.AddBook(book);
        }

        /// <summary>
        /// Запрос на автозаполнение из внешней БД Bookcity
        /// </summary>
        /// <param name="href">Ссылка книги</param>
        [HttpGet("books/bc/add")]
        public async Task<int> AddBcBook(string href)
        {
            try
            {
                var path = "https://murmuring-savannah-25756.herokuapp.com/ebs/bookcity/details/" + href;
                var user = await userBusinessService.GetUserByEmail(User.Identity.Name);
                var client = new HttpClient();
                var response = await client.GetAsync(path);
                var result = response.Content.ReadAsStringAsync().Result;
                var book = JsonConvert.DeserializeObject<BookDto>(result);
                book.UserId = user.Id;
                await bookBusinessService.AddBook(book);
                return 1;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Запрос на заполнение книги вручную
        /// </summary>
        /// <param name="title">Титул книги</param>
        /// <param name="author">Автор книги</param>
        /// <param name="desc">Описание книги</param>
        /// <param name="rate">Рейтинг книги</param>
        /// <returns></returns>
        [HttpGet("books/manual/add")]
        public async Task<int> AddManualBook(string title, string author, string desc, int rate)
        {
            var user = await userBusinessService.GetUserByEmail(User.Identity.Name);
            var book = new BookDto()
            {
                Title = title,
                Author = author,
                Description = desc,
                Rate = rate
            };
            book.UserId = user.Id;
            return await bookBusinessService.AddBook(book);
        }

        /// <summary>
        /// Поиск книг по ключевому тексту
        /// </summary>
        /// <param name="search">Ключевой текст</param>
        [HttpGet("books/index")]
        public async Task<IActionResult> GetBooksBySearch(string search, int minCount = 0)
        {
            var books = await bookBusinessService.GetBooksBySearchValue(search);
            books = GetMinCountOfBooks(minCount, books);
            var booksVM = new List<BookListViewModel>();
            foreach (var book in books)
            {
                var entity = mapper.Map<BookDto, BookListViewModel>(book);
                entity.UserEmail = book.User.Email;
                booksVM.Add(entity);
            }
            return Ok(booksVM);
        }

        /// <summary>
        /// Получить список книг по идентификатору пользователя
        /// </summary>
        [HttpGet("books/user/{id}")]
        public async Task<IActionResult> GetBooksByUserId(int id)
        {
            var books = await bookBusinessService.GetBooksByUserId(id);
            var booksVM = mapper.Map<List<BookDto>, List<BookListViewModel>>(books);
            return Ok(new { books = booksVM });
        }

        /// <summary>
        /// Получить количество книг в библиотеке по идентификатору пользователя
        /// </summary>
        [HttpGet("books/count/user/{id}")]
        public async Task<IActionResult> GetBooksCountByUserId(int id)
        {
            var books = await bookBusinessService.GetBooksByUserId(id);
            return Ok(new { count = books.Count });
        }

        [HttpGet("books/bookTop")]
        public async Task<IActionResult> GetTopBooksByClickCount()
        {
            var books = await bookBusinessService.GetBooks();
            var topBooks = books.OrderByDescending(s => s.СlickCount).Take(3).ToList();
            var booksVM = mapper.Map<List<BookDto>, 
                List<BookListViewModel>>(topBooks);
            return Ok(new { books = booksVM });
        }

        private List<BookDto> GetMinCountOfBooks(int minCount, List<BookDto> books)
        {
            if(minCount > 0)
            {
                return books.Take(minCount).ToList();
            }

            return books;
        }
    }
}