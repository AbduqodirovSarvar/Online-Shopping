using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shop.App.Abstracts;
using Shop.Infrastructue.Abstracts;
using Shop.Infrastructue.Database;
using Shop.Infrastructue.Providers;
using Shop.Infrastructue.Service;
using System.Text;

namespace Shop.Infrastructue
{
    public static class DepencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<IGetPasswordHash, GetPasswordHash>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = "ok",
                        ValidIssuer = "ok",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret"))
                    };
                });

            return services;
        }
    }
}
