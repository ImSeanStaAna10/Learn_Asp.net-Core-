using LoginAuthAPI.Contracts;
using LoginAuthAPI.Entities;
using LoginAuthAPI.Infrastructure;

namespace LoginAuthAPI.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;

        //dependecy Injection
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get user by email
        public User? GetByEmail(string email)
        {
            return _context.users
                .FirstOrDefault(U => U.Email == email);
        }

        //Add User  
        public void AddUser(User user)
        {
            _context.users.Add(user);
        }


        //Save Changes to DB
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        



    }
}
