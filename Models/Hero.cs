using HowToCreateWebAPI.Contracts;

namespace HowToCreateWebAPI.Models
{
    public class Hero : IbaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
