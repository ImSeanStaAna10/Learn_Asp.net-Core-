using HowToCreateWebAPI.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HowToCreateWebAPI.Controllers
{
    [Authorize] 
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        private readonly IBaseRepository<T> _repository;
        public BaseController(IBaseRepository<T> repository)
        {
            _repository = repository;
        }


        #region--CRUD--

        // Create
        [HttpPost]
        public IActionResult Create([FromBody] T User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repository.Add(User);
            return Ok();
        }

        // Retrieve 
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var user = _repository.GetOne(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // Update
        [HttpPut]
        public IActionResult Update([FromBody] T user)
        {
            // para I check lang kung valid ba or hindi yung model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            _repository.Update(user);
            return Ok();
        }

        // Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);

            return Ok();
        }
        #endregion

    }
}
