using LoginAuthAPI.Entities;

namespace LoginAuthAPI.Contracts
{
    public interface ITokenService 
    {
        string GenerateToken(User user);
        
    }
}
