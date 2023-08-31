
using System.Text;
using API.Services;
using Aplicacion.Contratos;
using Aplicacion.UnitOfWork;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Seguridad.TokenSeguridad;

namespace API.Extensions;

public static class ApplicationServiceExtension
{
   public static void ConfigureCors(this IServiceCollection services) =>
    services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin() //WithOrigins("https://domini.com")
                .AllowAnyMethod()       //WithMethods(*GET ", "POST")
                .AllowAnyHeader()      //WithHeaders(*accept*, "content-type")
            );

        }
    );

    public static void AddApplicationServices(this IServiceCollection services)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContextcontext"));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateAudience = false,
                ValidateIssuer = false
            };

        });
        //services.AddScoped<IEstadoInterface, EstadoRepository>();
        services.AddScoped<IJwtGeneradorInterface, JwtGenerador>();
        services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();
        services.AddScoped<IUserServiceInterface, UserService>();
        services.AddScoped<IUnitOfWorkInterface, UnitOfWork>();
    }

        
}
