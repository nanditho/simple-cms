using System.Collections.Generic;
using BlogApi.Dtos.Blog;
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

        [HttpGet]
    [ProducesResponseType(400)]
    [ProducesResponseType(400, Type = typeof(IEnumerable<UserDto>))]
    public IActionResult GetCountries()
    {
      var users = _repo.GetUsers();
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var usersDto = new List<UserDto>();
      foreach (var user in users)
      {
        usersDto.Add(new UserDto
        {
          Id = user.Id,
          Username = user.UserName
        });
      }
      return Ok(usersDto);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400, Type = typeof(UserDto))]
    public IActionResult GetUser(int id)
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

    [HttpGet("{id}/blog/")]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400, Type = typeof(IEnumerable<BlogDto>))]
    public IActionResult GetUserBlogs(int id)
    {
      if (!_repo.UserExists(id))
        return NotFound();

      var blogs = _repo.GetUserBlogPosts(id);

      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var blogsDto = new List<BlogDto>();
      foreach (var blog in blogsDto)
      {
        blogsDto.Add(new BlogDto
        {
          Id = blog.Id,
          Title = blog.Title,
          Content = blog.Content
        });
      }

      return Ok(blogsDto);
    }

    [HttpGet("{id}/comments/")]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400, Type = typeof(IEnumerable<UserDto>))]
    public IActionResult GetUserComments(int id)
    {
      if (!_repo.UserExists(id))
        return NotFound();

      var comments = _repo.GetUserComments(id);

      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var commentsDto = new List<CommentDto>();
      foreach (var comment in comments)
      {
        commentsDto.Add(new CommentDto
        {
          Id = comment.Id,
          Title = comment.Title,
          Content = comment.Content
        });
      }

      return Ok(commentsDto);
    }

    }
}