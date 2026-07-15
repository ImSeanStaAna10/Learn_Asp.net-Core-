using HowToCreateWebAPI.Models;

namespace HowToCreateWebAPI.Contracts
{
    public interface ItokenService
    {

        string GenerateToken(User user);
        bool isValid(string Token);
    }
}
