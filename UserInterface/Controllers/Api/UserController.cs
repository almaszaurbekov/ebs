using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Services.BusinessService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UserInterface.ViewModels;
using UserInterface.ViewModels.Entities;
namespace UserInterface.Controllers.Api
{
    public class UserController : EbsApiController
    {
        public UserController(IUserBusinessService userBusinessService,
            IMapper mapper, IWebHostEnvironment hostEnvironment) : base(userBusinessService, mapper, hostEnvironment)
        { }

        /// <summary>
        /// Список всех пользователей
        /// </summary>
        [HttpGet("users")]
        public async Task<IActionResult> Get(int minCount = 0)
        {
            var users = await userBusinessService.GetUsers();
            return GetMinCountOfUsers(minCount, users);
        }

        private OkObjectResult GetMinCountOfUsers(int minCount, List<UserDto> users)
        {
            if (minCount > 0)
            {
                return Ok(mapper.Map<List<UserDto>,
                    List<UserListViewModel>>(users).Take(minCount).ToList());   
            }

            return Ok(mapper.Map<List<UserDto>, List<UserListViewModel>>(users));
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
            if (me != null)
                usersVM.Remove(me);
            return Ok(usersVM);
        }

        /// <summary>
        /// Получить текущего аутентифицированного пользователя
        /// </summary>
        [HttpGet("users/me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userEmail = User.Identity.Name;
                var user = await userBusinessService.GetUserByEmail(userEmail);
                var userVM = mapper.Map<UserDto, UserViewModel>(user);
                return Ok(new { data = userVM, isSuccess = true });
            }
            return Ok(new { isSuccess = false });
        }

        /// <summary>
        /// Пользователи, у которых много книг
        /// </summary>
        [HttpGet("users/top")]
        public async Task<IActionResult> GetUsersOrderDescByBookCount()
        {
            var users = await userBusinessService.GetUsers();
            var topUsers = users.OrderByDescending(s => s.Books.Count).Take(3).ToList();
            var usersVM = mapper.Map<List<UserDto>, List<UserViewModel>>(topUsers);
            return Ok(new { data = usersVM } );
        }

        /// <summary>
        /// Скачать файл с тренингом
        /// </summary>
        [HttpGet("downloadTraining")]
        public IActionResult DownloadTraining()
        {
            var fileName = "EBS_Introduction.pdf";
            var filePath = $"~/pdf/{fileName}";
            Response.Headers.Add("Content-Disposition", $"inline; filename={fileName}");
            return File(filePath, "application/pdf");
        }
    }
}