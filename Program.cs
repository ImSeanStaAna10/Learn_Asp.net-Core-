using LoginAuthAPI.Contracts;
using LoginAuthAPI.Infrastructure;
using LoginAuthAPI.Repositories;
using LoginAuthAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LoginAuthAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            #region Constants
            const string JWT_SECTION = "JwtSettings";
            const string LOGIN_AUTH_API_CONTEXT_CONNSTRING = "AuthAPI";
            #endregion

            #region Create Web Application Builder

            // Creates the WebApplicationBuilder.
            // This is where we register services (Dependency Injection)
            // and configure the application's settings.
            var builder = WebApplication.CreateBuilder(args);

            #endregion

            #region Database Configuration
            // Registers the ApplicationDbContext into the Dependency Injection container.
            // EF Core will use this DbContext to communicate with SQL Server.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString(LOGIN_AUTH_API_CONTEXT_CONNSTRING));
            });

            #endregion

            #region Jwt_Configuration
            //Token Validation
            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Token Creation
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration[$"{JWT_SECTION}:Issuer"],

                        // Token Reciever
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration[$"{JWT_SECTION}:Audience"],

                        // Token expiry
                        ValidateLifetime = true,

                        // Token Digitial signature
                        ValidateIssuerSigningKey = true,

                        // Secret Key to validate JWT signature
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(
                             builder.Configuration[$"{JWT_SECTION}:SecretKey"]!

                                )
                            )
                    };

                });
            #endregion

            #region Register Framework Services

            // Registers MVC Controllers.
            builder.Services.AddControllers();

            // Register Swagger Services
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register Repository sa DI

            #region -- DI CONTAINER --
            builder.Services.AddScoped<IUserRepository , UserRepository>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            #endregion

            #endregion

            #region Build Application

            // Builds the application using the registered services.
            var app = builder.Build();

            #endregion

            #region Configure HTTP Request Pipeline

            // Runs only in the Development environment.
            if (app.Environment.IsDevelopment())
            {
                Console.WriteLine("APPLICATION IS RUNNING IN DEVELOPMENT MODE...");

                app.UseSwagger();
                app.UseSwaggerUI();

            }

            // Redirect HTTP requests to HTTPS.
            app.UseHttpsRedirection();

            // Authentication  
            app.UseAuthentication();

            // Enables authorization middleware.
            app.UseAuthorization();

            // Maps controller endpoints.
            app.MapControllers();

            #endregion

            #region Run Application

            // Starts the application.
            app.Run();

            #endregion
        }
    }
}