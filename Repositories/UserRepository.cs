using HowToCreateWebAPI.Contracts;
using HowToCreateWebAPI.Models;

namespace HowToCreateWebAPI.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepositorycs
    {

        private readonly ItokenService _tokenService;
        public UserRepository(ItokenService tokenService) : base() { 
            _tokenService = tokenService;
        }

        public string Login(string email, string password)
        {
            var foundUser = _Table
                .FirstOrDefault(u => u.Email == email && u.Password == password);

            return foundUser != null ? _tokenService.GenerateToken(foundUser) : null;
        }

    }
    
}
