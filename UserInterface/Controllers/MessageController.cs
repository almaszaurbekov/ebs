using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Services.BusinessService;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using UserInterface.ViewModels;

namespace UserInterface.Controllers
{
    public class MessageController : Controller
    {
        private readonly IUserBusinessService userBusinessService;
        private readonly IMessageBusinessService messageBusinessService;
        private readonly IMapper mapper;
        public MessageController(IUserBusinessService userBusinessService,
            IMessageBusinessService messageBusinessService, IMapper mapper)
        {
            this.userBusinessService = userBusinessService;
            this.messageBusinessService = messageBusinessService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var dialogs = await messageBusinessService.GetDialogs(User.Identity.Name);
            var dialogsVM = mapper.Map<List<DialogControl>, List<DialogViewModel>>(dialogs);
            return View(dialogsVM);
        }

        public async Task<IActionResult> StartMessage(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var user = await userBusinessService.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }

            var dialogControl = await messageBusinessService.CreateDialogControl(user.Id);

            return RedirectToAction("Dialog", new RouteValueDictionary(
                        new { controller = "Message", action = "Dialog", id = dialogControl.Id }));
        }

        public async Task<IActionResult> Dialog(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            return View();
        }
    }
}