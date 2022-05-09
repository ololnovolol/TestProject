using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using BusinessLogic.Models;
using DataAcessLayar.Entities;
using BusinessLogic.Services;
using BusinessLogic.Interfaces;

namespace BusinessLogic
{
    public static class BusinessLogicExtensions
    {
        public static IServiceCollection RegisterBusinessLogicServices(this IServiceCollection services)
        {
            // TODO: Register Business services
            services.AddTransient<IUserService, UserService>();

            ConfigureEntityToModelMapping(services);
            return services;
        }

        private static void ConfigureEntityToModelMapping(IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                // TODO: Register map items
                config.CreateMap<User, UserModel>();
            }).CreateMapper();
            services.AddSingleton(mapper);
        }
     }
}
