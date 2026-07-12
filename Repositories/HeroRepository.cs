using HowToCreateWebAPI.Contracts;
using HowToCreateWebAPI.Models;

namespace HowToCreateWebAPI.Repositories
{
    public class HeroRepository: BaseRepository<Hero>, IHeroRepository
    {
        public HeroRepository(): base() { }


        //DEMO EXTEND FUNCTION
        public IEnumerable<Hero> GetByAge(int age)
        {
            return _Table.Where(t => t.Age == age);

        }

    }
}
