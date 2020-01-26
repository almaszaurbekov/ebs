using BusinessLogic.Services.Base;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IDialogControlService : IService<DialogControl> { }
    public class DialogControlService : EntityService<DialogControl>, IDialogControlService
    {
        public DialogControlService(EbsContext context) : base(context) { }

        public override async Task<DialogControl> Find(Expression<Func<DialogControl, bool>> predicate)
        {
            return await DbSet
                .Where(predicate)
                .FirstOrDefaultAsync();
        }
    }
}
