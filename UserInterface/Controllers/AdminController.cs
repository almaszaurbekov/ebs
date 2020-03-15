using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Services.BusinessService;
using Microsoft.AspNetCore.Mvc;
using UserInterface.ViewModels;

namespace UserInterface.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBookBusinessService bookBusinessService;
        private readonly IUserBusinessService userBusinessService;
        private readonly IMapper mapper;

        public AdminController(IMapper mapper, IBookBusinessService bookBusinessService,
            IUserBusinessService userBusinessService)
        {
            this.bookBusinessService = bookBusinessService;
            this.userBusinessService = userBusinessService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var books = await bookBusinessService.GetBooks();
            var users = await userBusinessService.GetUsers();

            ViewData["BookList"] = mapper.Map<List<BookDto>,
                List<BookListViewModel>>(books.TakeLast(5).ToList());
            ViewData["UserList"] = mapper.Map<List<UserDto>, 
                List<UserListViewModel>>(users.TakeLast(5).ToList());

            return View();
        }
    }
}