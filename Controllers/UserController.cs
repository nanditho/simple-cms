using Microsoft.AspNetCore.Mvc;
using simple_cms.Data.Interfaces;
using simple_cms.Dtos.Blog;

namespace simple_cms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _repo;
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

    [HttpGet("{id}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400, Type = typeof(UserDto))]
    public IActionResult GetCUser(int id)
    {
      if (!_repo.UserExists(id))
        return NotFound();

      var user = _repo.GetUser(id);

      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var userDto = new UserDto()
      {
        Id = user.Id,
        Username = user.UserName,
      };

      return Ok(userDto);
    }

    }
}