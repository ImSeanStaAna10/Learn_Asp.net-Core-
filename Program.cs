using HowToCreateWebAPI.Contracts;
using HowToCreateWebAPI.Infrastructure;
using HowToCreateWebAPI.Repositories;
using HowToCreateWebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HowToCreateWebAPI
{
    public class Program
    {
        #region Constants

        // Configuration key used to retrieve the JWT Secret Key
        // from appsettings.json.
        private const string SECRET_CONFIG_KEY = "MySecretKey";

        #endregion

        public static void Main(string[] args)
        {
            #region Create Application Builder

            // Creates the WebApplicationBuilder.
            // This is where we configure services (Dependency Injection)
            // and application settings before building the application.
            var builder = WebApplication.CreateBuilder(args);

            #endregion

            #region Read Application Configuration

            // Retrieves the JWT Secret Key stored inside appsettings.json.
            // This key is used to sign and validate JWT tokens.
            var secret = builder.Configuration.GetValue<string>(SECRET_CONFIG_KEY);

            #endregion

            #region Configure JWT Validation Parameters

            // These parameters define how incoming JWT tokens
            // will be validated every time a protected endpoint is accessed.
            var validationParameters = new TokenValidationParameters
            {
                // Skip issuer validation.
                ValidateIssuer = false,

                // Skip audience validation.
                ValidateAudience = false,

                // Verify that the signing key is valid.
                ValidateIssuerSigningKey = true,

                // Reject expired tokens.
                ValidateLifetime = true,

                // Empty because issuer validation is disabled.
                ValidIssuer = string.Empty,

                // Empty because audience validation is disabled.
                ValidAudience = string.Empty,

                // Secret key used to verify the token signature.
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(secret!))
            };

            #endregion

            #region Register MVC Controllers

            // Registers all API Controllers into the Dependency Injection container.
            builder.Services.AddControllers();

            #endregion

            #region Register Database

            // Registers the Fake Database as a Singleton.
            // Only one instance will exist during the application's lifetime.
            builder.Services.AddSingleton<FakeDbContext>();

            #endregion

            #region Register Repositories

            // Registers the User Repository.
            builder.Services.AddSingleton<IUserRepositorycs, UserRepository>();

            // Registers the Hero Repository.
            builder.Services.AddSingleton<IHeroRepository, HeroRepository>();

            // Registers the Generic Base Repository.
            builder.Services.AddSingleton(
                typeof(IBaseRepository<>),
                typeof(BaseRepository<>));

            #endregion

            #region Register Services

            // Registers the Token Service responsible for:
            // - Creating JWT Tokens
            // - Validating JWT Tokens
            builder.Services.AddSingleton<ItokenService>(
                serviceProvider => new TokenService(validationParameters, secret!));

            #endregion

            #region Register Authentication

            // Enables JWT Authentication.
            // Every request containing an Authorization Header
            // will be validated using the TokenValidationParameters.
            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = validationParameters;
                });

            #endregion

            #region Register Authorization

            // Enables Authorization.
            // This allows the use of attributes such as:
            //
            // [Authorize]
            // [AllowAnonymous]
            //
            builder.Services.AddAuthorization();

            #endregion

            

            #region Build Application

            // Builds the application.
            // After this point, services can no longer be registered.
            var app = builder.Build();

            #endregion

            #region Configure Middleware Pipeline

            // Displays the current running environment.
            Console.WriteLine($"Environment: {app.Environment.EnvironmentName}");


            // Redirects HTTP requests to HTTPS.
            app.UseHttpsRedirection();

            // Authenticates the current request.
            // If a JWT Token exists, it is validated here.
            app.UseAuthentication();

            // Checks whether the authenticated user
            // has permission to access the requested endpoint.
            app.UseAuthorization();

            // Maps all Controller Routes.
            app.MapControllers();

            #endregion

            #region Run Application

            // Starts listening for incoming HTTP Requests.
            app.Run();

            #endregion
        }
    }
}