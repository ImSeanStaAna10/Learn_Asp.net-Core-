using HowToCreateWebAPI.Contracts;

namespace HowToCreateWebAPI.Models
{
    public class Position : IbaseModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
