using BusinessLogic.Services.Base;
using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    public interface IDialogControlService : IService<DialogControl> { }
    public class DialogControlService : EntityService<DialogControl>, IDialogControlService
    {
        public DialogControlService(EbsContext context) : base(context) { }
    }
}
