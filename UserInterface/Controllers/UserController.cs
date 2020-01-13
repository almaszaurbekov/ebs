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

namespace UserInterface.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserBusinessService userBusinessService;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IMapper mapper;

        public UserController(IUserBusinessService userBusinessService, IMapper mapper,
            IWebHostEnvironment hostEnvironment)
        {
            this.userBusinessService = userBusinessService;
            this.hostEnvironment = hostEnvironment;
            this.mapper = mapper;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var user = await userBusinessService.GetUserByEmail(User.Identity.Name);
            ViewBag.Role = user.Role.Name;
            ViewBag.Id = user.Id;
            return View();
        }

        // GET: User/Details/5
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

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Password,FirstName,LastName,ImageSource,Address,Id")] User user)
        {
            if (ModelState.IsValid)
            {
                await userBusinessService.CreateUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
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

        // POST: User/Edit/5
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
                    entity = mapper.Map<UserViewModel, User>(model);

                    // Обновляем фотку
                    if (model.Image != null)
                        entity.ImageSource = CreateFile(model.Image.FileName, model.Image);

                    // Если фотку хотят удалить
                    if (model.RemoveImage)
                        entity.ImageSource = null;

                    //await userBusinessService.UpdateUser(user);

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
                return RedirectToAction(nameof(Details));
            }
            return View(model);
        }

        // GET: User/Delete/5
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

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await userBusinessService.GetUserById(id);
            await userBusinessService.DeleteUser(user);
            return RedirectToAction(nameof(Index));
        }

        // GET: User/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        // POST: User/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await userBusinessService.GetUserByEmailAndPassword(model.Email, model.Password);
                if (user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        // GET: User/SignUp
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignUp()
        {
            return View();
        }

        // POST: User/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await userBusinessService.GetUserByEmail(model.Email);
                if (user == null)
                {
                    user = new User { Email = model.Email, Password = PasswordHelper.Hash(model.Password) };
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

        // GET: User/Logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
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
            string folder = Path.Combine(hostEnvironment.WebRootPath, "images");
            fileName = Guid.NewGuid().ToString() + "_" + imgfileName;
            string filepath = Path.Combine(folder, fileName);
            image.CopyTo(new FileStream(filepath, FileMode.Create));
            return fileName;
        }
    }
}
