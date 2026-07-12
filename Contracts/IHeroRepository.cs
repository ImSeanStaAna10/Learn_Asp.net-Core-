using HowToCreateWebAPI.Models;

namespace HowToCreateWebAPI.Contracts
{
    public interface IHeroRepository : IBaseRepository<Hero> {

        //DEMO EXTEND Funciton
        IEnumerable<Hero> GetByAge(int age);


    }
    
}
