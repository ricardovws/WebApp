using Microsoft.Extensions.DependencyInjection;
using System;
using WebNothing.Application.Interfaces;
using WebNothing.Application.Services;
using WebNothing.Data.Repositories;
using WebNothing.Domain.Interfaces;

namespace WebNothing.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services
            services.AddScoped<IUserService, UserService>();
            #endregion

            #region Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

        }
    }
}
