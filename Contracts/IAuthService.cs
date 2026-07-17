using LoginAuthAPI.DTO_S;

namespace LoginAuthAPI.Contracts
{
    public interface IAuthService
    {
        AuthResponseDTO Register(RegisterRequestDTO request);

        AuthResponseDTO Login(LoginRequestDTO request);
    }
}
