using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Services.BusinessService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<IActionResult> Get()
        {
            var users = await userBusinessService.GetUsers();
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
    }
}