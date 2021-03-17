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

            CreateMap<UserViewModel, User>()
                //ignore id!
                .ForMember(dest => dest.Id, act => act.Ignore());

            #endregion

            #region DomainToViewModel

            CreateMap<User, UserViewModel>()
                //ignore password when push this data to frontend!
                .ForMember(dest => dest.Password, act => act.Ignore());

            #endregion
        }
    }
}
