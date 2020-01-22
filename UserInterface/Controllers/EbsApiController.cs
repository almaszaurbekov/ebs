using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Services;
using BusinessLogic.Services.BusinessService;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserInterface.ViewModels.Entities;

namespace UserInterface.Controllers
{
    [Route("api/ebs")]
    [ApiController]
    public class EbsApiController : ControllerBase
    {
        private readonly IUserBusinessService userBusinessService;
        private readonly IBookBusinessService bookBusinessService;
        private readonly IBcBookService bookcityService;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment hostEnvironment;
        private string folder;

        public EbsApiController(IUserBusinessService userBusinessService, IMapper mapper,
            IWebHostEnvironment hostEnvironment, IBookBusinessService bookBusinessService,
            IBcBookService bookcityService)
        {
            this.userBusinessService = userBusinessService;
            this.bookBusinessService = bookBusinessService;
            this.bookcityService = bookcityService;
            this.mapper = mapper;
            this.hostEnvironment = hostEnvironment;
            this.folder = Path.Combine(hostEnvironment.WebRootPath, "files");
        }

        [HttpGet("test")]
        public string Test()
        {
            return "200 OK";
        }

        [HttpPost("user/edit")]
        public async Task<int> Edit(UserViewModel model)
        {
            try
            {
                var entity = await userBusinessService.GetUserById(model.Id);

                ReplaceValue(model.Email, entity.Email);
                ReplaceValue(model.FirstName, entity.FirstName);
                ReplaceValue(model.LastName, entity.LastName);
                ReplaceValue(model.Address, entity.Address);

                if (model.Image != null)
                    entity.ImageSource = CreateFile(model.Image.FileName, model.Image);
                
                if (model.RemoveImage)
                    entity.ImageSource = null;

                if (User.Identity.Name != entity.Email)
                {
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimsIdentity.DefaultNameClaimType, entity.Email)
                        };

                    ClaimsIdentity claimsId = new ClaimsIdentity(claims, "ApplicationCookie",
                        ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsId));
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        [HttpGet("books/byvalue")]
        public async Task<List<BcBook>> BooksByValue(string value)
        {
            var books = await bookcityService.GetBooksByValue(value);
            return books.Take(50).ToList();
        }

        [HttpGet("books/add")]
        public async Task<int> AddBook(int id)
        {
            var user = await userBusinessService.GetUserByEmail(User.Identity.Name);
            var bcbook = await bookcityService.Find(s => s.Id == id);
            var book = mapper.Map<BcBook, Book>(bcbook);
            book.Id = 0;
            book.UserId = user.Id;
            return await bookBusinessService.AddBook(book);
        }

        private void ReplaceValue(object newValue, object oldValue)
        {
            if (newValue != null)
                oldValue = newValue;
        }

        /// <summary>
        /// Функция по созданию файла в wwwroot/images
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
