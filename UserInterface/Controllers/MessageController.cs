using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Services.BusinessService;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using UserInterface.ViewModels;

namespace UserInterface.Controllers
{
    [Authorize]
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
            return View(dialogsVM.OrderByDescending(s => s.LastMessageDate).ToList());
        }

        public async Task<IActionResult> DialogByUser(int? id)
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

            var me = await userBusinessService.GetUserByEmail(User.Identity.Name);
            var dialog = await messageBusinessService.GetDialogControlByInterlocutorsId(me.Id, user.Id);

            if (dialog == null)
            {
                dialog = new DialogControl()
                {
                    CreatedBy = User.Identity.Name,
                    FirstInterlocutorEmail = User.Identity.Name,
                    FirstInterlocutorId = me.Id,
                    SecondInterlocutorEmail = user.Email,
                    SecondInterlocutorId = user.Id
                };

                dialog = await messageBusinessService.CreateDialogControl(dialog);
            }

            return RedirectToAction("Dialog", new { id = dialog.Id });
        }

        public async Task<IActionResult> Dialog(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var dialog = await messageBusinessService.GetDialogControlById(id);
            if (dialog == null)
            {
                return NotFound();
            }

            var userId = dialog.FirstInterlocutorEmail == User.Identity.Name ? 
                dialog.SecondInterlocutorId : dialog.FirstInterlocutorId;

            var user = await userBusinessService.GetUserById(userId);
            var me = await userBusinessService.GetUserByEmail(User.Identity.Name);

            ViewBag.Receiver = user;
            ViewBag.Me = me;
            ViewBag.DialogId = id;

            var dialogVM = mapper.Map<DialogControl, DialogViewModel>(dialog);
            dialogVM.Messages = await messageBusinessService.GetMessagesByDialogId(id);

            return View(dialogVM);
        }
    }
}