using HowToCreateWebAPI.Models;

namespace HowToCreateWebAPI.Contracts
{
    public interface IUserRepositorycs: IBaseRepository<User>
    {
        public string Login(string email, string password);
    }
}
