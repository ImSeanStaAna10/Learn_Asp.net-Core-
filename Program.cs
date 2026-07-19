using LoginAuthAPI.Contracts;
using LoginAuthAPI.Infrastructure;
using LoginAuthAPI.Repositories;
using LoginAuthAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace LoginAuthAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Create Web Application Builder

            // Creates the WebApplicationBuilder.
            // This is where we register services (Dependency Injection)
            // and configure the application's settings.
            var builder = WebApplication.CreateBuilder(args);

            #endregion

            #region Database Configuration

            // Name of the connection string found in appsettings.json
            const string LOGIN_AUTH_API_CONTEXT_CONNSTRING = "AuthAPI";

            // Registers the ApplicationDbContext into the Dependency Injection container.
            // EF Core will use this DbContext to communicate with SQL Server.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString(LOGIN_AUTH_API_CONTEXT_CONNSTRING));
            });

            #endregion

            #region Register Framework Services

            // Registers MVC Controllers.
            builder.Services.AddControllers();

            // Register Repository sa DI
            builder.Services.AddScoped<IUserRepository , UserRepository>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ITokenService, TokenService>();

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
            }

            // Redirect HTTP requests to HTTPS.
            app.UseHttpsRedirection();

            // Authentication will be added later after JWT configuration.
            // app.UseAuthentication();

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