using System.Threading.Tasks;
using BlogApi.Data.Interfaces;
using BlogApi.Dtos.Register;
using BlogApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  [AllowAnonymous]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _repo;
    public AuthController(IAuthRepository repo)
    {
      _repo = repo;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDto request)
    {
      ServiceResponse<string> response = await _repo.Register(
          new User { UserName = request.UserName }, request.Password);
      if (!response.Success)
      {
        return BadRequest(response);
      }
      return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserToLoginDto request)
    {
      ServiceResponse<string> response = await _repo.Login(
          request.Username, request.Password);
      if (!response.Success)
      {
        return BadRequest(response);
      }
      return Ok(response);
    }
  }
}