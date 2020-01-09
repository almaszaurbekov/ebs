using BusinessLogic.Services.Base;
using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    public interface IUserService : IService<User> { }

    public class UserService : EntityService<User>, IUserService
    {
        public UserService(EbsContext context) : base(context) { }
    }
}
