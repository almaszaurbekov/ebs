using BusinessLogic.Services.Base;
using DataAccess;
using DataAccess.Entities;

namespace BusinessLogic.Services
{
    public interface IRoleService : IService<Role> { }
    public class RoleService : EntityService<Role>, IRoleService
    {
        public RoleService(EbsContext context) : base(context) { }
    }
}
