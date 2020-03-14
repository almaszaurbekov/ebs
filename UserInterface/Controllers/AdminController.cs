using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Services.BusinessService;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBookBusinessService bookBusinessService;
        private readonly IMapper mapper;

        public AdminController(IMapper mapper, IBookBusinessService bookBusinessService)
        {
            this.bookBusinessService = bookBusinessService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var books = await bookBusinessService.GetBooks();
            ViewBag.Books = books;
            return View();
        }
    }
}