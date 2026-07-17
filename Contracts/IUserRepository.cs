using LoginAuthAPI.Entities;

namespace LoginAuthAPI.Contracts
{
    public interface IUserRepository 
    {
        //get user by email
        User? GetByEmail(string Email);

        //Add new User

        void AddUser(User user);

        //save changes to DB
        void SaveChanges();
        

        
    }
}
