using System.Collections.Generic;
using BlogApi.Data.Interfaces;
using BlogApi.Dtos.Blog;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoriesController : Controller
  {
    private readonly ICategoryRepository _repo;

    public CategoriesController(ICategoryRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    [ProducesResponseType(400)]
    [ProducesResponseType(400, Type = typeof(IEnumerable<CategoryDto>))]
    public IActionResult GetCategories()
    {
      var categories = _repo.GetCategories();
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var categoriesDto = new List<CategoryDto>();
      foreach (var category in categoriesDto)
      {
        categoriesDto.Add(new CategoryDto
        {
          Id = category.Id,
          Name = category.Name
        });
      }
      return Ok(categoriesDto);
    }


    [HttpGet("{id}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400, Type = typeof(CategoryDto))]
    public IActionResult GetCategory(int id)
    {
      if (!_repo.CategoryExists(id))
        return NotFound();

      var category = _repo.GetCategory(id);

      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var categoryDto = new CategoryDto()
      {
        Id = category.Id,
        Name = category.Name
      };

      return Ok(categoryDto);
    }


  }
}