using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using UserInterface.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using BusinessLogic.Services.BusinessService;
using UserInterface.ViewModels.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using UserInterface.Controllers.Base;
using BusinessLogic.Dto;
using System.Linq;
using AutoMapper;
using Common;
namespace UserInterface.Controllers
{
    [Authorize]
    public class UserController : BaseMvcController
    {
        private readonly IUserBusinessService userBusinessService;
        private readonly IBookBusinessService bookBusinessService;

        public UserController(IUserBusinessService userBusinessService, IMapper mapper,
            IWebHostEnvironment hostEnvironment, IBookBusinessService bookBusinessService)
            : base(mapper, hostEnvironment)
        {
            this.userBusinessService = userBusinessService;
            this.bookBusinessService = bookBusinessService;
        }

        /// <summary>
        /// Главная страница приложения
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var user = await userBusinessService.GetUserByEmail(User.Identity.Name);
            if(user == null)
            {
                return NotFound();
            }

            ViewData["Role"] = user.Role.Name;
            ViewData["Id"] = user.Id;
            ViewData["TrCount"] = await bookBusinessService.GetCountOfBookRequests(user.Id);

            return View();
        }

        /// <summary>
        /// Профиль пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await userBusinessService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            var userVM = mapper.Map<UserDto, UserViewModel> (user);
            return View(userVM);
        }

        /// <summary>
        /// Создать пользователя
        /// </summary>
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("Email,Password,FirstName,LastName,ImageSource,Address,Id")] UserDto user)
        {
            if (ModelState.IsValid)
            {
                await userBusinessService.CreateUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        /// <summary>
        /// Изменить данные пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await userBusinessService.GetUserById(id);
            if (user == null || user.Email != User.Identity.Name)
            {
                return NotFound();
            }

            var userVM = mapper.Map<UserDto, UserViewModel>(user);
            return View(userVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserViewModel model)
        {
            if (id != model.Id || model.Email != User.Identity.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var entity = await userBusinessService.GetUserById(model.Id);
                    entity = mapper.Map(model, entity);

                    if (model.Image != null)
                        entity.ImageSource = CreateFile(model.Image.FileName, model.Image);

                    if (model.RemoveImage)
                        entity.ImageSource = null;

                    await userBusinessService.UpdateUser(entity);

                    if (User.Identity.Name != entity.Email)
                        await UpdateCookie(entity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await UserExists(model.Id))
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

        /// <summary>
        /// Удалить профиль
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await userBusinessService.GetUserById(id);
            if (user == null || user.Email != User.Identity.Name)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await userBusinessService.GetUserById(id);
            await userBusinessService.DeleteUser(user);
            return await Logout();
        }

        /// <summary>
        /// Список пользователей
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await userBusinessService.GetUsers();
            var usersVM = mapper.Map<List<UserDto>, List<UserViewModel>>(users);
            var me = usersVM.Where(s => s.Email == User.Identity.Name).FirstOrDefault();
            usersVM.Remove(me);
            return View(usersVM);
        }

        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userBusinessService.GetUserByEmailAndPassword(model.Email.ToLower(), model.Password);
                if (user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var email = model.Email.ToLower();
                var user = await userBusinessService.GetUserByEmail(email);
                if (user == null)
                {
                    user = new UserDto { Email = email, Password = PasswordHelper.Hash(model.Password) };
                    RoleDto role = await userBusinessService.GetRoleByName("user");
                    if (role != null){
                        user.RoleId = role.Id;
                    }
                    
                    user = await userBusinessService.CreateUser(user);

                    await Authenticate(user);

                    return RedirectToAction("Index", "User");
                }
                else
                    ModelState.AddModelError("", "Пользователь с таким email уже существует");
            }
            return View(model);
        }

        /// <summary>
        /// Выйти из профиля
        /// </summary>
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

        /// <summary>
        /// Проверка на наличие пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        private async Task<bool> UserExists(int id)
        {
            return await userBusinessService.GetUserById(id) != null;
        }
    }
}