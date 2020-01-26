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
        Task<DialogControl> CreateDialogControl(DialogControl dialogControl);
        Task<DialogControl> GetDialogControlById(int? id);
        Task<DialogControl> GetDialogControlByUserId(int userId);
        Task<DialogControl> GetDialogControlByInterlocutorsId(int firstIntercolutorId, int secondIntercolutorId);
        Task<List<Message>> GetMessagesByDialogId(int? id);
        Task<Message> CreateMessage(Message message);
        Task<int> UpdateDialog(int id, string text);
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

        public async Task<DialogControl> CreateDialogControl(DialogControl dialogControl)
        {
            return await dialogControlService.Create(dialogControl);
        }

        public async Task<Message> CreateMessage(Message message)
        {
            return await messageService.Create(message);
        }

        public async Task<DialogControl> GetDialogControlById(int? id)
        {
            return await dialogControlService.Find(s => s.Id == id);
        }

        public async Task<DialogControl> GetDialogControlByInterlocutorsId(int firstIntercolutorId, 
            int secondIntercolutorId)
        {
            return await dialogControlService
                .Find(s => (s.FirstInterlocutorId == firstIntercolutorId && 
                    s.SecondInterlocutorId == secondIntercolutorId) ||
                (s.SecondInterlocutorId == firstIntercolutorId && 
                    s.FirstInterlocutorId == secondIntercolutorId));
        }

        public Task<DialogControl> GetDialogControlByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DialogControl>> GetDialogs(string email)
        {
            return await dialogControlService
                .Filter(s => s.FirstInterlocutorEmail == email || s.SecondInterlocutorEmail == email);
        }

        public async Task<List<Message>> GetMessagesByDialogId(int? id)
        {
            return await messageService.Filter(s => s.DialogControlId == id);
        }

        public async Task<int> UpdateDialog(int id, string text)
        {
            var dialog = await dialogControlService.Find(s => s.Id == id);
            dialog.LastMessage = text;
            dialog.LastMessageDate = DateTime.Now;
            return await dialogControlService.Update(dialog);
        }
    }
}
