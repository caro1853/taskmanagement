using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tasking.Application.Behaviours;
using FluentValidation;
using Tasking.Application.Operations;

namespace Tasking.Application
{
	public static class ApplicationServiceRegistration
	{
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient<ITaskOperations, TaskOperations>();

            return services;
        }
    }
}

