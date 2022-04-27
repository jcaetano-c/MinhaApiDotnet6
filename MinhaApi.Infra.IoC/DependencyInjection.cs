using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Infra.Data.Context;
using System;
using MinhaApi.Domain.Repositories;
using MinhaApi.Infra.Data.Repositories;
using AutoMapper;
using MinhaApi.Application.Mappings;
using MinhaApi.Application.Services.Interfaces;
using MinhaApi.Application.Services;

namespace MinhaApi.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            service.AddScoped<IPersonRepository, PersonRepository>();

            return service;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IPersonService, PersonService>();
            return services;
        }
    }
}
