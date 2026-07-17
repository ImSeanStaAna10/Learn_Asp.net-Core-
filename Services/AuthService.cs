using LoginAuthAPI.Contracts;
using LoginAuthAPI.DTO_S;

namespace LoginAuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public AuthResponseDTO Register(RegisterRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public AuthResponseDTO Login(LoginRequestDTO request)
        {
            throw new NotImplementedException();
        }
    }
}