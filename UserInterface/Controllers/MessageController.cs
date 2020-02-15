using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Dto;
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
        #region Initialize

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

        #endregion

        /// <summary>
        /// Список диалогов
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var dialogs = await messageBusinessService.GetDialogs(User.Identity.Name);
            var dialogsVM = mapper.Map<List<DialogControlDto>, List<DialogViewModel>>(dialogs);
            return View(dialogsVM.OrderByDescending(s => s.LastMessageDate).ToList());
        }

        /// <summary>
        /// Диалог по пользователю (получатель)
        /// </summary>
        /// <param name="id">Идентификатор получателя</param>
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
                dialog = new DialogControlDto()
                {
                    FirstInterlocutorEmail = User.Identity.Name,
                    FirstInterlocutorId = me.Id,
                    SecondInterlocutorEmail = user.Email,
                    SecondInterlocutorId = user.Id
                };

                dialog.Id = await messageBusinessService.CreateDialogControl(dialog);
            }

            return RedirectToAction("Dialog", new { id = dialog.Id });
        }

        /// <summary>
        /// Страница диалог с пользователем
        /// </summary>
        /// <param name="id">Идентификатор диалога</param>
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

            var dialogVM = mapper.Map<DialogControlDto, DialogViewModel>(dialog);
            dialogVM.Messages = await messageBusinessService.GetMessagesByDialogId(id);

            return View(dialogVM);
        }
    }
}