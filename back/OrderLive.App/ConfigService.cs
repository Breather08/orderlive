using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OrderLive.App.Common;
using OrderLive.App.Login;
using System;

namespace OrderLive.App
{
    public static class ConfigService
    {
        public static void AddApp(this IServiceCollection services, Type type)
        {
            //Common
            services.AddValidators();
            services.AddMediatR(r => r.RegisterServicesFromAssemblyContaining(type));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

            services.AddMediatR(r => r.RegisterServicesFromAssembly(typeof(LoginCommandHandler).Assembly));


        }

        private static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<LoginValidator>();
        }
    }
}
