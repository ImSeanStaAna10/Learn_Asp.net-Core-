using HowToCreateWebAPI.Contracts;
using HowToCreateWebAPI.Infrastructure;
using HowToCreateWebAPI.Repositories;

namespace HowToCreateWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Creates the WebApplicationBuilder.
            // This is where we configure services (Dependency Injection)
            // and application settings before building the app.
            var builder = WebApplication.CreateBuilder(args);

            // ============================================================
            // Register Services (Dependency Injection Container)
            // ============================================================

            // Registers MVC/Web API Controllers.
            // Required so the application can discover and use controllers.
            builder.Services.AddControllers();

            // Registers FakeDbContext as a Singleton.
            // Since this is an in-memory fake database, we only need
            // one instance shared throughout the application's lifetime.
            builder.Services.AddSingleton<FakeDbContext>();

            // Registers the Generic Repository.
            // Whenever ASP.NET Core needs IBaseRepository<T>,
            // it will automatically create and inject BaseRepository<T>.
            builder.Services.AddSingleton(
                typeof(IBaseRepository<>),
                typeof(BaseRepository<>)
            );

            builder.Services.AddSingleton<IHeroRepository, HeroRepository>();

            // Builds the application using the registered services.
            var app = builder.Build();

            // ============================================================
            // Configure HTTP Request Pipeline (Middleware)
            // ============================================================

            // Redirects HTTP requests to HTTPS for secure communication.
            app.UseHttpsRedirection();

            // Checks whether the current user is authorized
            // to access protected endpoints.
            // (Useful when JWT Authentication is implemented.)
            app.UseAuthorization();

            // Maps incoming HTTP requests to the appropriate Controller
            // based on routing attributes such as [Route] and [HttpGet].
            app.MapControllers();

            // Starts the Web API and begins listening for incoming requests.
            app.Run();
        }
    }
}