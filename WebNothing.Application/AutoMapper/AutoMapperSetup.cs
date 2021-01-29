using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebNothing.Application.ViewModels;
using WebNothing.Domain.Entities;

namespace WebNothing.Application.AutoMapper
{
    public class AutoMapperSetup :  Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain

            CreateMap<UserViewModel, User>();

            #endregion

            #region DomainToViewModel

            CreateMap<User, UserViewModel>();

            #endregion
        }
    }
}
