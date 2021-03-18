using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebNothing.Application.Interfaces;
using WebNothing.Application.ViewModels;
using WebNothing.Auth.Services;
using WebNothing.Data.Validators;
using WebNothing.Data.Validators.ErrorMessage;
using WebNothing.Domain.Entities;
using WebNothing.Domain.Interfaces;
//using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

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

        public string Post(UserViewModel userViewModel)
        {

            User _user = mapper.Map<User>(userViewModel);

            var errors = new ErrorMessageBuilder().IsItOk(_user, userViewModel.ConfirmPassword).Errors;

            if (errors.Any())
            {
                return JsonConvert.SerializeObject(errors);
            }

            _user.DateCreated = DateTime.UtcNow;

            _user.Password = authService.EncryptPassword(_user.Password);

            this.userRepository.Create(_user);

            return JsonConvert.SerializeObject("That's nice. The user has been added succesfully.");
            
        }

        public UserViewModel GetById(int id)
        {
            User _user = this.userRepository.Find(x => x.Id == id && !x.IsDeleted);
            
            if (_user == null)
                throw new Exception("User not found");


            return mapper.Map<UserViewModel>(_user);
        }

        public string Put(UserViewModel userViewModel)
        {
            User _user = mapper.Map<User>(userViewModel);

            User user = this.userRepository.Find(x => x.Id == userViewModel.Id && !x.IsDeleted);

            if (user is null)
            {
                return JsonConvert.SerializeObject("User not found.");
            }

            bool ignorePasswordUpdate = false;

            if (string.IsNullOrEmpty(userViewModel.Password) && userViewModel.Password == userViewModel.ConfirmPassword)
            {
                ignorePasswordUpdate = true;
            }

            var errors = new ErrorMessageBuilder().IsItOk(_user, userViewModel.ConfirmPassword, ignorePasswordUpdate).Errors;

            if (errors.Any())
            {
                return JsonConvert.SerializeObject(errors);
            }

            user.Name = userViewModel.Name;
            user.Email = userViewModel.Email;                
            user.DateUpdated = DateTime.UtcNow;
            user.Password = userViewModel.Password;

            this.userRepository.Update(user);

            return JsonConvert.SerializeObject("That's nice. The user has been updated succesfully.");
        }

        public string Delete(int id)
        {
            User _user = this.userRepository.Find(x => x.Id == id && !x.IsDeleted);

            if (_user is null)
            {
                return JsonConvert.SerializeObject("User not found.");
            }

            this.userRepository.Delete(_user);

            return JsonConvert.SerializeObject("The user has been deleted.");
        }
    }
}
