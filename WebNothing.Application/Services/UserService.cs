﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebNothing.Application.Interfaces;
using WebNothing.Application.ViewModels;
using WebNothing.Domain.Entities;
using WebNothing.Domain.Interfaces;

namespace WebNothing.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        private readonly IMapper mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public List<UserViewModel> Get()
        {
            IEnumerable<User> _users = this.userRepository.GetAll();

            List<UserViewModel> _userViewModels = mapper.Map<List<UserViewModel>>(_users);

            return _userViewModels;
        }

        public bool Post(UserViewModel userViewModel)
        {
          
            User _user = mapper.Map<User>(userViewModel);

            _user.DateCreated = DateTime.Now;

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

            this.userRepository.Update(_user);

            return true;
        }

    }
}
