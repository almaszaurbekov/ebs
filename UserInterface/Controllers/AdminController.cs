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

        public IActionResult Index()
        {
            return View();
        }
    }
}