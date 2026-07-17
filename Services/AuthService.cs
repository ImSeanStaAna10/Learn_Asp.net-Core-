using LoginAuthAPI.Contracts;
using LoginAuthAPI.DTO_S;
using LoginAuthAPI.Entities;

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
            var existingUser = _userRepository.GetByEmail(request.Email);

            if (existingUser != null)
            {
                return new AuthResponseDTO
                {
                    Message = "Email Already Exist"
                };
            }

            //MAP DTO to Entity
            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = "User"

            }; 

            //Add and Save User
            _userRepository.AddUser(user);
            _userRepository.SaveChanges();

            return new AuthResponseDTO
            {
                Message = "User Registered Succesfull"
            };
        }

        public AuthResponseDTO Login(LoginRequestDTO request)
        {
            var user = _userRepository.GetByEmail(request.Email);

            if (user == null)
            {
                return new AuthResponseDTO
                {
                    Message = "Invalid Email Or Password"
                };

            }


            //Verify Pass
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.PasswordHash
                );

            if(!isPasswordValid)
            {
                return new AuthResponseDTO
                {
                    Message = "Invalid Email Or Password"
                };

            };

            return new AuthResponseDTO
            {
                Message = "Login Succesfull"
            };


        }
    }
}