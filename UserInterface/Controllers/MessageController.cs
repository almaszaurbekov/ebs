using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Services;
using BusinessLogic.Services.BusinessService;
using Microsoft.AspNetCore.Mvc;
using UserInterface.ViewModels;

namespace UserInterface.Controllers
{
    public class MessageController : Controller
    {
        private readonly IUserBusinessService userBusinessService;
        private readonly IMessageService messageService;

        public MessageController(IUserBusinessService userBusinessService,
            IMessageService messageService)
        {
            this.userBusinessService = userBusinessService;
            this.messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            var messages = await messageService.GetMessagesByUserEmail(User.Identity.Name);
            return View(messages);
        }

        public async Task<IActionResult> Dialog(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var receiverEntity = await userBusinessService.GetUserById(id);
            if(receiverEntity == null)
            {
                return NotFound();
            }
            var meEntity = await userBusinessService.GetUserByEmail(User.Identity.Name);
            //var messages = await userBusinessService.GetUsersAllMessages(meEntity, receiverEntity);

            return View();
        }
    }
}