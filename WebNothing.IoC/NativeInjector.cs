using Microsoft.Extensions.DependencyInjection;
using System;
using WebNothing.Application.Interfaces;
using WebNothing.Application.Services;

namespace WebNothing.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
