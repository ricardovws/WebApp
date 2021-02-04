using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebNothing.Application.Services;
using WebNothing.Application.ViewModels;
using WebNothing.Domain.Entities;
using WebNothing.Domain.Interfaces;
using Xunit;

namespace WebNothing.Application.Tests.Services
{
    public class UserServiceTests
    {
             
        private UserService userService;

        public UserServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<UserViewModel, User>();
            });

            var mapper = config.CreateMapper();

            userService = new UserService(new Mock<IUserRepository>().Object, mapper);
                       
        }

        [Fact]
        public void Post_SendingValidId()
        {
            var exception = Assert.Throws<Exception>(() => userService.Post(new UserViewModel { Id = 1, Name = "Jorge Ferreira", Email = "teucfdbrilh@cdu.com" }));

            Assert.Equal("UserID must be zero or empty", exception.Message);
        }

        [Fact]
        public void GetById_SendingIdEqualsToZero()
        {
            var exception = Assert.Throws<Exception>(() => userService.GetById(0));
            Assert.Equal("User not found", exception.Message);
        }

        [Fact]
        public void GetById_SendingNegativeId()
        {
            var exception = Assert.Throws<Exception>(() => userService.GetById(-1));
            Assert.Equal("User not found", exception.Message);
        }

        [Fact]
        public void Put_SendingIdEqualsToZero()
        {
            var exception = Assert.Throws<Exception>(() => userService.Put(new UserViewModel { Id = 0, Name = "José das Couves", Email = "nothingless@n.com"}));
            Assert.Equal("User not found", exception.Message);
        }

        [Fact]
        public void Put_SendingNegativeId()
        {
            var exception = Assert.Throws<Exception>(() => userService.Put(new UserViewModel { Id = -2, Name = "José das Couves", Email = "nothingless@n.com" }));
            Assert.Equal("User not found", exception.Message);
        }

        [Fact]
        public void Delete_SendingIdEqualsToZero()
        {
            var exception = Assert.Throws<Exception>(() => userService.Delete(0));
            Assert.Equal("User not found", exception.Message);
        }

        [Fact]
        public void Delete_SendingNegativeId()
        {
            var exception = Assert.Throws<Exception>(() => userService.Delete(-23));
            Assert.Equal("User not found", exception.Message);
        }

        [Fact]
        public void Authenticate_SendingEmptyValues()
        {
            var exception = Assert.Throws<Exception>(() => userService.Authenticate(new UserAuthenticateRequestViewModel()));
            Assert.Equal("Email/Password are required.", exception.Message);
        }
    }
}
