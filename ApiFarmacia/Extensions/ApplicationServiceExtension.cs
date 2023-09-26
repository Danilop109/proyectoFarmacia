using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.UnitOfWork;
using Dominio.Interfaces;

namespace ApiFarmacia.Extensions;
    public static class ApplicationServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options => 
        {
            options.AddPolicy("CorsPolicy", builder => 
            builder.AllowAnyOrigin()      //WithOrigins (https://domini.com)
            .AllowAnyMethod()             //WithMethods ("GET", "POST")
            .AllowAnyHeader());           //WithHeaders (*accept*, "content-type")
        });

        public static void AddAplicacionServices(this IServiceCollection services)
            {
                // services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
                // services.AddScoped<IUserService, UserService>(); 
                services.AddScoped<IUnitOfWork, UnitOfWork>();
            }
    }
