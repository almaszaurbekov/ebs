using AutoMapper;
using AutoMapper.Configuration;
using BusinessLogic.Dto;
using BusinessLogic.Mappings;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.BusinessService
{
    public interface IMessageBusinessService
    {
        Task<List<DialogControlDto>> GetDialogs(string email);
        Task<int> CreateDialogControl(DialogControlDto dialogControl);
        Task<DialogControlDto> GetDialogControlById(int? id);
        Task<DialogControlDto> GetDialogControlByUserId(int userId);
        Task<DialogControlDto> GetDialogControlByInterlocutorsId(int firstIntercolutorId, int secondIntercolutorId);
        Task<List<MessageDto>> GetMessagesByDialogId(int? id);
        Task<int> CreateMessage(MessageDto message);
        Task<int> UpdateDialog(int id, string text);
    }

    public class MessageBusinessService : IMessageBusinessService
    {
        #region Initialize

        private readonly IMessageService messageService;
        private readonly IDialogControlService dialogControlService;
        private readonly IMapper mapper;

        public MessageBusinessService(IMessageService messageService,
            IDialogControlService dialogControlService)
        {
            this.messageService = messageService;
            this.dialogControlService = dialogControlService;
            this.mapper = MapperConfig.MapperInitialize();
        }

        #endregion

        public async Task<int> CreateDialogControl(DialogControlDto dialogControl)
        {
            var entity = mapper.Map<DialogControlDto, DialogControl>(dialogControl);
            var result = await dialogControlService.Create(entity);
            return result.Id;
        }

        public async Task<int> CreateMessage(MessageDto message)
        {
            var entity = mapper.Map<MessageDto, Message>(message);
            var result = await messageService.Create(entity);
            return result.Id;
        }

        public async Task<DialogControlDto> GetDialogControlById(int? id)
        {
            var dialog = await dialogControlService.Find(s => s.Id == id);
            return mapper.Map<DialogControl, DialogControlDto>(dialog);
        }

        public async Task<DialogControlDto> GetDialogControlByInterlocutorsId(int firstIntercolutorId, 
            int secondIntercolutorId)
        {
            var dialog = await dialogControlService
                .Find(s => (s.FirstInterlocutorId == firstIntercolutorId &&
                    s.SecondInterlocutorId == secondIntercolutorId) ||
                (s.SecondInterlocutorId == firstIntercolutorId &&
                    s.FirstInterlocutorId == secondIntercolutorId));
            return mapper.Map<DialogControl, DialogControlDto>(dialog);
        }

        public Task<DialogControlDto> GetDialogControlByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DialogControlDto>> GetDialogs(string email)
        {
            var dialogs = await dialogControlService
                .Filter(s => s.FirstInterlocutorEmail == email || s.SecondInterlocutorEmail == email);
            return mapper.Map<List<DialogControl>, List<DialogControlDto>>(dialogs);
        }

        public async Task<List<MessageDto>> GetMessagesByDialogId(int? id)
        {
            var messages = await messageService.Filter(s => s.DialogControlId == id);
            return mapper.Map<List<Message>, List<MessageDto>>(messages);
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
