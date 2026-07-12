using HowToCreateWebAPI.Contracts;
using HowToCreateWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HowToCreateWebAPI.Controllers
{
    public class PositionController : BaseController<Position>
    {
        
        public PositionController(IBaseRepository<Position> repository) : base(repository)
        {

        }
    }
}
