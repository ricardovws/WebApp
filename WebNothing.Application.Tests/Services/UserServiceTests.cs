using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebNothing.Application.AutoMapper;
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

        #region ValidatingSendingId

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
        #endregion

        #region ValidatingCorrenctObject

        [Fact]
        public void Post_SendingValidObject()
        {
            var result = userService.Post(new UserViewModel { Name = "Manuel", Email = "manuel.manual@mm.com" });
            Assert.True(result);
        }

        [Fact]
        public void Get_ValidatingObject()
        {
            List<User> _users = new List<User>();
            _users.Add(new User { Id = 1, Name = "Jorge", Email = "jorge@jorge.com", DateCreated = DateTime.Now });

            var _userRepository = new Mock<IUserRepository>();

            _userRepository.Setup(x => x.GetAll()).Returns(_users);

            var _autoMapperProfile = new AutoMapperSetup();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);

            userService = new UserService(_userRepository.Object, _mapper);
            
            var result = userService.Get();
            Assert.True(result.Count > 0);

        }

        #endregion

        #region ValidatingRequiredFields

        [Fact]
        public void Post_SendingInvalidObject()
        {
            var exception = Assert.Throws<ValidationException>(() => userService.Post(new UserViewModel { Name = "Manuel" }));
            Assert.Equal("The Email field is required.", exception.Message);
        }

        #endregion
    }
}
