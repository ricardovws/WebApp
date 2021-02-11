using AutoMapper;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using WebNothing.Application.Interfaces;
using WebNothing.Application.ViewModels;
using WebNothing.Auth.Services;
using WebNothing.Domain.Entities;
using WebNothing.Domain.Interfaces;

namespace WebNothing.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;

        private readonly IMapper mapper;
        public AuthService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                throw new Exception("Email/Password are required.");

            user.Password = EncryptPassword(user.Password);


            User _user = this.userRepository.Find(x => !x.IsDeleted && x.Email.ToLower() == user.Email.ToLower() && x.Password.ToLower() == user.Password.ToLower());
            if (_user == null)
                throw new Exception("User not found");

            return new UserAuthenticateResponseViewModel(mapper.Map<UserViewModel>(_user), TokenService.GenerateToken(_user));
        }

        public bool IsAuthenticated()
        {
            return true;
        }

        //preciso trocar para private!
        public string EncryptPassword(string password)
        {
            HashAlgorithm sha = new SHA1CryptoServiceProvider();

            byte[] encryptedPassword = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var caracter in encryptedPassword)
            {
                stringBuilder.Append(caracter.ToString("X2"));
            }

            return stringBuilder.ToString();
        }

    }
}
