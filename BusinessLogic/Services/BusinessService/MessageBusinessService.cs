using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.BusinessService
{
    public interface IMessageBusinessService
    {
        Task<List<DialogControl>> GetDialogs(string email);
        Task<DialogControl> CreateDialogControl(int userId);
    }

    public class MessageBusinessService : IMessageBusinessService
    {
        private readonly IMessageService messageService;
        private readonly IDialogControlService dialogControlService;

        public MessageBusinessService(IMessageService messageService,
            IDialogControlService dialogControlService)
        {
            this.messageService = messageService;
            this.dialogControlService = dialogControlService;
        }

        public async Task<DialogControl> CreateDialogControl(int userId)
        {
            return new DialogControl();
        }

        public async Task<List<DialogControl>> GetDialogs(string email)
        {
            var dialogIds = await messageService.GetDialogIds(email);
            var dialogs = new List<DialogControl>();
            foreach(var id in dialogIds)
                dialogs.Add(await dialogControlService.Find(s => s.Id == id));

            return dialogs;
        }

        
    }
}
