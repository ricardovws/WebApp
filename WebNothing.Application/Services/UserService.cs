using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using WebNothing.Application.Interfaces;
using WebNothing.Application.ViewModels;
using WebNothing.Auth.Services;
using WebNothing.Domain.Entities;
using WebNothing.Domain.Interfaces;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace WebNothing.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        private readonly IMapper mapper;

        private readonly IAuthService authService;
        public UserService(IUserRepository userRepository, IMapper mapper, IAuthService authService)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.authService = authService;
        }
        public List<UserViewModel> Get()
        {
            IEnumerable<User> _users = this.userRepository.GetAll();

            List<UserViewModel> _userViewModels = mapper.Map<List<UserViewModel>>(_users);

            return _userViewModels;
        }

        public bool Post(UserViewModel userViewModel)
        {

            if (userViewModel.Id != 0)
                throw new Exception("UserID must be zero or empty");

            Validator.ValidateObject(userViewModel, new ValidationContext(userViewModel), true);

            User _user = mapper.Map<User>(userViewModel);

            _user.DateCreated = DateTime.Now;

            _user.Password = authService.EncryptPassword(_user.Password);

            this.userRepository.Create(_user);

            return true;
        }

        public UserViewModel GetById(int id)
        {
            User _user = this.userRepository.Find(x => x.Id == id && !x.IsDeleted);
            
            if (_user == null)
                throw new Exception("User not found");


            return mapper.Map<UserViewModel>(_user);
        }

        public bool Put(UserViewModel userViewModel)
        {
            User _user = this.userRepository.Find(x => x.Id == userViewModel.Id && !x.IsDeleted);

            if (_user == null)
                throw new Exception("User not found");

            _user = mapper.Map<User>(userViewModel);

            _user.Password = authService.EncryptPassword(_user.Password);

            this.userRepository.Update(_user);

            return true;
        }

        public bool Delete(int id)
        {
            User _user = this.userRepository.Find(x => x.Id == id && !x.IsDeleted);

            if (_user == null)
                throw new Exception("User not found");

            return this.userRepository.Delete(_user); 
        }
    }
}
