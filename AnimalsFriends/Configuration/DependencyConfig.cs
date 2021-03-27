using IdentityServer4.Validation;
using LoginApi.Contracts.Repositories;
using LoginApi.Contracts.Services;
using LoginApi.Controllers;
using LoginApi.Repositories;
using LoginApi.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsFriends.Configuration
{
    public class DependencyConfig
    {
        public static void Populate(IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterServices(services);
            RegisterControllers(services);
        }

        private static void RegisterControllers(IServiceCollection services)
        {
            services.AddTransient(typeof(UserController));
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient(typeof(IUserService), typeof(UserService));
            services.AddTransient(typeof(IResourceOwnerPasswordValidator), typeof(ResourceOwnerPasswordValidator));
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
        }
    }
}
