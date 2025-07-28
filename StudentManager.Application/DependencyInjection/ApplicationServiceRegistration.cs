using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using FluentValidation;
using StudentManager.Application.Behavior;

namespace StudentManager.Application.DependencyInjection
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //services.AddAutoMapper(cfg =>
            //{
            //    cfg.CreateMap<User, UserDto>();
            //});
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<Mapping.MappingProfile>();
            });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
