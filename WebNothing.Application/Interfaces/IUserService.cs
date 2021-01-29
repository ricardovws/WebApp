using System;
using System.Collections.Generic;
using System.Text;
using WebNothing.Application.ViewModels;

namespace WebNothing.Application.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> Get();
        bool Post(UserViewModel userViewModel);
    }   
}
