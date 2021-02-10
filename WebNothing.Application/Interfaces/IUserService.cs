﻿using System;
using System.Collections.Generic;
using System.Text;
using WebNothing.Application.ViewModels;

namespace WebNothing.Application.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> Get();
        bool Post(UserViewModel userViewModel);
        UserViewModel GetById(int id);
        bool Put(UserViewModel userViewModel);

        public bool Delete(int id);

        UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user);

        bool IsAuthenticated();
    }   
}
