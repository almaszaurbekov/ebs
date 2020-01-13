using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Services.BusinessService;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{
    public class MessageController : Controller
    {
        private readonly IUserBusinessService userBusinessService;

        public MessageController(IUserBusinessService userBusinessService)
        {
            this.userBusinessService = userBusinessService;
        }

        public IActionResult Index()
        {
            return View();
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