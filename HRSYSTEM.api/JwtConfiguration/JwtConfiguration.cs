using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace HRSYSTEM.api.JwtConfiguration
{
    /// <summary>
    /// This class will enbales JWT Authentication Service
    /// </summary>
    public static class JwtConfiguration
    {
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Auth:Jwt:Key"]));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuerSigningKey = true,
                    RequireExpirationTime = true,
                    ValidIssuer = configuration["Auth:Jwt:Issuer"],
                    ValidAudience = configuration["Auth:Jwt:Audience"],
                    IssuerSigningKey = signingKey
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        // If the token does'nt validate correctly
                        Console.WriteLine($"OnAuthenticationFailed {context.Exception.Message}");
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        // Allows to look if the token validates correctly the token
                        Console.WriteLine($"OnTokenValidated {context.SecurityToken}");
                        return Task.CompletedTask;
                    }
                };
            });

            return services;
        }
    }
}
