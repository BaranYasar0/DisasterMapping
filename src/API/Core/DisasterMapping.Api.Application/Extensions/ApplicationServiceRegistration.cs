using DisasterMapping.Api.Application.CCS.Pipelines;
using DisasterMapping.Api.Application.Features.Rules.Disasters;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Application.Extensions
{
    public static class ApplicationServiceRegistration
    {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(x =>
            
                x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddHttpContextAccessor();

            services.AddScoped<DisasterBusinessRules>();

            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationPipelineBehaviour<,>));

            return services;
        }
    }
}
