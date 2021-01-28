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
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public List<UserViewModel> Get()
        {
            List<UserViewModel> _userViewModels = new List<UserViewModel>();

            IEnumerable<User> _users = this.userRepository.GetAll();

            foreach(var user in _users)
                _userViewModels.Add(new UserViewModel { Id = user.Id, Email = user.Email, Name = user.Name });

            return _userViewModels;
        }
    }
}
