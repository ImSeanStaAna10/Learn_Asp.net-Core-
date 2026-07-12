using HowToCreateWebAPI.Contracts;
using HowToCreateWebAPI.Models;

namespace HowToCreateWebAPI.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepositorycs
    {
        public UserRepository() : base() { }

    }
    
}
