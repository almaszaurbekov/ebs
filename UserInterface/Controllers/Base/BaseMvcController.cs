using AutoMapper;
using BusinessLogic.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UserInterface.Controllers.Base
{
    public class BaseMvcController : Controller
    {
        protected readonly IWebHostEnvironment hostEnvironment;
        protected readonly IMapper mapper;

        public BaseMvcController(IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
            this.mapper = mapper;
        }

        /// <summary>
        /// Функция по созданию файла в wwwroot/img
        /// </summary>
        /// <param name="imgfileName">Имя файла, отправленного пользователем</param>
        /// <param name="image">HtppRequest фотографии</param>
        protected string CreateFile(string imgfileName, IFormFile image)
        {
            string fileName = null;
            string folder = Path.Combine(hostEnvironment.WebRootPath, "img");
            fileName = Guid.NewGuid().ToString() + "_" + imgfileName;
            string filepath = Path.Combine(folder, fileName);
            image.CopyTo(new FileStream(filepath, FileMode.Create));
            return fileName;
        }

        /// <summary>
        /// Алгоритм аутентификации
        /// </summary>
        /// <param name="user">Пользователь</param>
        protected async Task Authenticate(UserDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email.ToLower()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        /// <summary>
        /// Обновление куки
        /// </summary>
        /// <param name="user">Текущий пользователь</param>
        /// <returns></returns>
        protected async Task UpdateCookie(UserDto user)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)
            };

            ClaimsIdentity claimsId = new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsId));
        }
    }
}
