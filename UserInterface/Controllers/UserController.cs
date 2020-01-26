using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using UserInterface.ViewModels;
using Resources;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using BusinessLogic.Services.BusinessService;
using UserInterface.ViewModels.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace UserInterface.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserBusinessService userBusinessService;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IBookBusinessService bookBusinessService;
        private readonly IMapper mapper;

        public UserController(IUserBusinessService userBusinessService, IMapper mapper,
            IWebHostEnvironment hostEnvironment, IBookBusinessService bookBusinessService)
        {
            this.userBusinessService = userBusinessService;
            this.bookBusinessService = bookBusinessService;
            this.hostEnvironment = hostEnvironment;
            this.mapper = mapper;
        }

        // Главная страница приложения
        public async Task<IActionResult> Index()
        {
            var user = await userBusinessService.GetUserByEmail(User.Identity.Name);
            var transactionsCount = await bookBusinessService.GetCountOfBookRequests(user.Id);
            ViewBag.Role = user.Role.Name;
            ViewData["Id"] = user.Id;
            ViewData["TrCount"] = transactionsCount;
            return View();
        }

        // Профиль пользователя
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

            var userVM = mapper.Map<User, UserViewModel> (user);

            return View(userVM);
        }

        // Создать пользователя
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("Email,Password,FirstName,LastName,ImageSource,Address,Id")] User user)
        {
            if (ModelState.IsValid)
            {
                await userBusinessService.CreateUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // Изменить данные пользователя
        public async Task<IActionResult> Edit(int? id)
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

            var userVM = mapper.Map<User, UserViewModel>(user);
            return View(userVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserViewModel model)
        {
            if (id != model.Id)
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

        // Удалить профиль
        public async Task<IActionResult> Delete(int? id)
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

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await userBusinessService.GetUsers();
            var usersVM = mapper.Map<List<User>, List<UserViewModel>>(users);
            var me = usersVM.Where(s => s.Email == User.Identity.Name).FirstOrDefault();
            usersVM.Remove(me);
            return View(usersVM);
        }

        // Аутентификация пользователя
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
                User user = await userBusinessService.GetUserByEmailAndPassword(model.Email.ToLower(), model.Password);
                if (user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        // Регистрация пользователя
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
                User user = await userBusinessService.GetUserByEmail(email);
                if (user == null)
                {
                    user = new User { Email = email, Password = PasswordHelper.Hash(model.Password) };
                    Role role = await userBusinessService.GetRoleByName("user");
                    if (role != null)
                        user.Role = role;
                    
                    await userBusinessService.CreateUser(user);

                    await Authenticate(user);

                    return RedirectToAction("Index", "User");
                }
                else
                    ModelState.AddModelError("", "Пользователь с таким email уже существует");
            }
            return View(model);
        }

        // Выйти из профиля
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

        private async Task Authenticate(User user)
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

        private async Task<bool> UserExists(int id)
        {
            return await userBusinessService.GetUserById(id) != null;
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
    }
}
