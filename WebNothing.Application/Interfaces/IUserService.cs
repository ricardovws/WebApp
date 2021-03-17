using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebNothing.Application.ViewModels;

namespace WebNothing.Application.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> Get();
        string Post(UserViewModel userViewModel);
        UserViewModel GetById(int id);
        string Put(UserViewModel userViewModel);

        public bool Delete(int id);
    }   
}
