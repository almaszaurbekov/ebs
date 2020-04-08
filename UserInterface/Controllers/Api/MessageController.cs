using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Services.BusinessService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.Controllers.Api
{
    public class MessageController : EbsApiController
    {
        public MessageController(IMessageBusinessService messageBusinessService,
          IMapper mapper, IWebHostEnvironment hostEnvironment) : base(messageBusinessService, mapper, hostEnvironment)
        { }

        /// <summary>
        /// Запрос на добавление нового сообщения
        /// </summary>
        [HttpGet("message/add")]
        public async Task<bool> MessageCreate(int dialogId, int senderId, int receiverId,
            string sender, string receiver, string text)
        {
            try
            {
                var message = new MessageDto()
                {
                    UserSenderEmail = sender,
                    UserSenderId = senderId,
                    UserReceiverEmail = receiver,
                    UserReceiverId = receiverId,
                    Text = text,
                    DialogControlId = dialogId
                };

                await messageBusinessService.CreateMessage(message);
                await messageBusinessService.UpdateDialog(dialogId, text);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
