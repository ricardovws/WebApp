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

            //Validate all data
            //var errorList = new ErrorMessage();

            //if(userViewModel.Password != userViewModel.ConfirmPassword)
            //{
            //    errorList.Errors.Add("Both passwords must match!");
            //}

            //User _user = mapper.Map<User>(userViewModel);
            //UserValidator validator = new UserValidator();
            //ValidationResult results = validator.Validate(_user);

            //if (results.IsValid == false)
            //{
            //    foreach(ValidationFailure failure in results.Errors)
            //    {
            //        errorList.Errors.Insert(0, $"{failure.ErrorMessage}");
            //    }

            //    return JsonConvert.SerializeObject(errorList);
            //}

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

        public bool Put(UserViewModel userViewModel)
        {
            User _user = this.userRepository.Find(x => x.Id == userViewModel.Id && !x.IsDeleted);

            if (_user == null)
                throw new Exception("User not found");

            _user.Name = userViewModel.Name;
            _user.Email = userViewModel.Email;
            
            //if(userViewModel.Password != null && userViewModel.ConfirmPassword != null)
            //{
            //    if (userViewModel.Password == userViewModel.ConfirmPassword)
            //        _user.Password = authService.EncryptPassword(userViewModel.Password);
            //}
                
            _user.DateUpdated = DateTime.UtcNow;
            //_user = mapper.Map<User>(userViewModel);

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
