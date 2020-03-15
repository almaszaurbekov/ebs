using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Services;
using BusinessLogic.Services.BusinessService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserInterface.ViewModels;
using UserInterface.ViewModels.Entities;

namespace UserInterface.Controllers
{
    [Route("api/ebs")]
    [ApiController]
    public class EbsApiController : ControllerBase
    {
        #region Initialize

        private readonly IUserBusinessService userBusinessService;
        private readonly IBookBusinessService bookBusinessService;
        private readonly IMessageBusinessService messageBusinessService;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment hostEnvironment;
        private string folder;

        public EbsApiController(IUserBusinessService userBusinessService, IMapper mapper,
            IWebHostEnvironment hostEnvironment, IBookBusinessService bookBusinessService,
            IMessageBusinessService messageBusinessService)
        {
            this.userBusinessService = userBusinessService;
            this.bookBusinessService = bookBusinessService;
            this.messageBusinessService = messageBusinessService;
            this.hostEnvironment = hostEnvironment;
            this.folder = Path.Combine(hostEnvironment.WebRootPath, "files");
            this.mapper = mapper;
        }

        #endregion

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
                return await bookBusinessService.AddBook(book);
            }
            catch
            {
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
        public async Task<IActionResult> GetBooksBySearch(string search)
        {
            var books = await bookBusinessService.GetBooksBySearchValue(search);
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
        /// Поиск пользователей по ключевому тексту
        /// </summary>
        /// <param name="search">Ключевой текст</param>
        [HttpGet("users/list")]
        public async Task<IActionResult> GetUsersBySearch(string search)
        {
            var users = await userBusinessService.GetUsersBySearch(search);
            var usersVM = mapper.Map<List<UserDto>, List<UserViewModel>>(users);
            var me = usersVM.Where(s => s.Email == User.Identity.Name).FirstOrDefault();
            if(me != null)
                usersVM.Remove(me);
            return Ok(usersVM);
        }

        /// <summary>
        /// Запрос на успешную транзакцию
        /// </summary>
        /// <param name="id">Идентификатор транзакции</param>
        [HttpGet("transactions/accept")]
        public async Task<bool> TransactionAccept(string id)
        {
            try
            {
                var transaction = await bookBusinessService.GetBookTransactionById(new Guid(id));
                transaction.OwnerAgreed = 1;
                await bookBusinessService.UpdateBookTransaction(transaction);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Запрос на отмену транзакции
        /// </summary>
        /// <param name="id">Идентификатор транзакции</param>
        [HttpGet("transactions/cancel")]
        public async Task<bool> TransactionCancel(string id)
        {
            try
            {
                var transaction = await bookBusinessService.GetBookTransactionById(new Guid(id));
                transaction.OwnerAgreed = 0;
                transaction.IsSuccess = 0;
                await bookBusinessService.UpdateBookTransaction(transaction);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Запрос на добавление нового сообщения
        /// </summary>
        [HttpGet("message/add")]
        public async Task<bool> MessageCreate(int dialogId, int senderId, int receiverId, 
            string sender, string receiver, string text)
        {
            try
            {
                var message = new MessageDto()
                {
                    UserSenderEmail = sender,
                    UserSenderId = senderId,
                    UserReceiverEmail = receiver,
                    UserReceiverId = receiverId,
                    Text = text,
                    DialogControlId = dialogId
                };

                await messageBusinessService.CreateMessage(message);
                await messageBusinessService.UpdateDialog(dialogId, text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Функция по созданию файла в wwwroot/img
        /// </summary>
        /// <param name="imgfileName">Имя файла, отправленного пользователем</param>
        /// <param name="image">HtppRequest фотографии</param>
        private string CreateFile(string imgfileName, IFormFile image)
        {
            string fileName = null;
            string folder = Path.Combine(hostEnvironment.WebRootPath, "images");
            fileName = Guid.NewGuid().ToString() + "_" + imgfileName;
            string filepath = Path.Combine(folder, fileName);
            image.CopyTo(new FileStream(filepath, FileMode.Create));
            return fileName;
        }
    }
}