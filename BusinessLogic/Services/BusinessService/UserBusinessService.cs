using DataAccess.Entities;
using Microsoft.Extensions.Caching.Memory;
using Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.BusinessService
{
    public interface IUserBusinessService
    {
        Task<User> GetUserById(int? id);
        Task<User> GetUserByEmail(string email);
        Task<List<User>> GetUsersBySearch(string email);
        Task<User> GetUserByEmailAndPassword(string email, string password);
        Task<List<User>> GetUsers();
        Task<User> CreateUser(User entity);
        Task<int> UpdateUser(User entity);
        Task<int> DeleteUser(User entity);
        Task<Role> GetRoleById(Guid? id);
        Task<Role> GetRoleByName(string name);
        Task<List<Role>> GetRoles();
    }

    public class UserBusinessService : IUserBusinessService
    {
        #region Initialize

        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly IMemoryCache cache;

        public UserBusinessService(IUserService userService, IMemoryCache cache,
            IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.cache = cache;
        }

        #endregion

        public async Task<User> GetUserByEmail(string email)
        {
            return await userService.Find(s => s.Email == email);
        }

        public async Task<User> GetUserById(int? id)
        {
            User user = null;
            if (!cache.TryGetValue(id, out user))
            {
                user = await userService.Find(s => s.Id == id);
                if (user != null)
                {
                    cache.Set(user.Id, user,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(30)));
                }
            }

            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            return await userService.GetAll();
        }

        public async Task<int> UpdateUser(User entity)
        {
            return await userService.Update(entity);
        }

        public async Task<User> CreateUser(User entity)
        {
            var result = await userService.Create(entity);
            if (result != null)
            {
                cache.Set(entity.Id, entity, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
                });
            }
            return result;
        }

        public async Task<int> DeleteUser(User entity)
        {
            return await userService.Delete(entity);
        }

        public async Task<Role> GetRoleById(Guid? id)
        {
            Role role = null;
            if (!cache.TryGetValue(id, out role))
            {
                role = await roleService.Find(s => s.Id == id);
                if (role != null)
                {
                    cache.Set(role.Id, role,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(30)));
                }
            }

            return role;
        }

        public async Task<List<Role>> GetRoles()
        {
            return await roleService.GetAll();
        }

        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            return await userService.Find(s => s.Email == email &&
                    s.Password == PasswordHelper.Hash(password));
        }

        public async Task<Role> GetRoleByName(string name)
        {
            return await roleService.Find(s => s.Name == name);
        }

        public async Task<List<User>> GetUsersBySearch(string email)
        {
            return await userService.Filter(s => s.Email.Contains(email.ToLower()));
        }
    }
}