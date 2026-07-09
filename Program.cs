using Microsoft.EntityFrameworkCore;
using WebNetCoreEntittyFramework.Entities;

namespace WebNetCoreEntittyFramework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            var config = builder.Configuration;
            const string  STUDENDB_CONTEXT_CONNSTRING = "Student";
            //Register DbContext dependecy injection Container
            builder.Services.AddDbContext<StudentDbContext>(options =>
            {
                options.UseSqlServer(
                  builder.Configuration.GetConnectionString(STUDENDB_CONTEXT_CONNSTRING));

            },  ServiceLifetime.Singleton);
            builder.Services.AddHostedService<Worker>();
            var host = builder.Build();
            host.Run();
        }
    }
}
