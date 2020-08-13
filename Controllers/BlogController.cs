using System.Collections.Generic;
using System.Threading.Tasks;
using BlogApi.Data.Interfaces;
using BlogApi.Dtos.Blog;
using BlogApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class BlogController : ControllerBase
  {
    private readonly IBlogService _service;
    public BlogController(IBlogService service)
    {
      _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      return Ok(await _service.GetAllBlogs());
    }

    [HttpPost]
    public async Task<IActionResult> AddBlog(AddBlogDto newBlog)
    {
      return Ok(await _service.AddBlog(newBlog));
    }


  }
}