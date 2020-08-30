using System.Collections.Generic;
using BlogApi.Data.Interfaces;
using BlogApi.Dtos.Blog;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CountryController : Controller
  {
    private readonly ICountryRepository _repo;
    public CountryController(ICountryRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    [ProducesResponseType(400)]
    [ProducesResponseType(400, Type = typeof(IEnumerable<CountryDto>))]
    public IActionResult GetCountries()
    {
      var countries = _repo.GetCountries();
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var countriesDto = new List<CountryDto>();
      foreach (var country in countries)
      {
        countriesDto.Add(new CountryDto
        {
          Id = country.Id,
          Name = country.Name
        });
      }
      return Ok(countriesDto);
    }

    [HttpGet("{countryId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400, Type = typeof(CountryDto))]
    public IActionResult GetCountry(int countryId)
    {
      if (!_repo.CountryExists(countryId))
        return NotFound();

      var country = _repo.GetCountry(countryId);

      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var countryDto = new CountryDto()
      {
        Id = country.Id,
        Name = country.Name
      };

      return Ok(countryDto);
    }
    //api/country/user/userId
    [HttpGet("user/{userId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400, Type = typeof(CountryDto))]
    public IActionResult GetCountryOfAUser(int userId)
    {
      var country = _repo.GetCountryOfAUser(userId);

      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var countryDto = new CountryDto()
      {
        Id = country.Id,
        Name = country.Name
      };

      return Ok(countryDto);
    }
  }
}