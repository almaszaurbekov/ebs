using AutoMapper;
using DataAccess.Entities;
using Microsoft.AspNetCore.Hosting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UserInterface.ViewModels.Entities;
using Xunit;

namespace UnitTest.AutoMapper
{
    public class UserController
    {
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment hostEnvironment;

        public UserController(IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
            this.mapper = mapper;
        }

        [Fact]
        public void UserVMToUser()
        {
            var userVM = new UserViewModel();
            var user = new User();

            userVM.FirstName = "Almas";
            user.Email = "foxxychmoxy@gmail.com";

            user = mapper.Map<UserViewModel, User>(userVM);

            Assert.Equal("foxxychmoxy@gmail.com", user.Email);
        }
    }
}
