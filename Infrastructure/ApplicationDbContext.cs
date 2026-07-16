using LoginAuthAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoginAuthAPI.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> _option) : base(_option)
        {

        }


        public DbSet<User> users { get; set; }



    }
}
