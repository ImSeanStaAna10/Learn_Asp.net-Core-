using HowToCreateWebAPI.Contracts;
using HowToCreateWebAPI.Infrastructure;
using HowToCreateWebAPI.Repositories;

namespace HowToCreateWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create the application builder.
            var builder = WebApplication.CreateBuilder(args);

            // ==================================================
            // Dependency Injection (Services)
            // ==================================================

            // Register API controllers.
            builder.Services.AddControllers();

            // Register Fake Database.
            builder.Services.AddSingleton<FakeDbContext>();

            // Register Generic Repository.
            builder.Services.AddSingleton(
                typeof(IBaseRepository<>),
                typeof(BaseRepository<>)
            );

            // Register Hero Repository.
            builder.Services.AddSingleton<IHeroRepository, HeroRepository>();

            // Build the application.
            var app = builder.Build();

            Console.WriteLine($"Environment: {app.Environment.EnvironmentName}");

            // ==================================================
            // HTTP Request Pipeline (Middleware)
            // ==================================================

            // Redirect HTTP requests to HTTPS.
            app.UseHttpsRedirection();

            // Authenticate the current user.
            app.UseAuthentication();

            // Check user permissions.
            app.UseAuthorization();

            // Map controller endpoints.
            app.MapControllers();

            // Start the application.
            app.Run();
        }
    }
}