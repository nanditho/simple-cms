using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogApi.Data.Interfaces;
using BlogApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BlogApi.Data
{
  public class AuthRepository : IAuthRepository
  {
    private readonly DataContext _context;
    private readonly IConfiguration _config;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signinManager;
    private readonly IMapper _mapper;

    public AuthRepository(DataContext context, IConfiguration config, UserManager<User> userManager, SignInManager<User> signinManager, IMapper mapper)
    {
      _mapper = mapper;
      _signinManager = signinManager;
      _userManager = userManager;
      _config = config;
      _context = context;
    }
    public async Task<ServiceResponse<string>> Login(string username, string password)
    {
      ServiceResponse<string> response = new ServiceResponse<string>();
      var user = await _userManager.FindByNameAsync(username);
      var result = await _signinManager.CheckPasswordSignInAsync(user, password, false);
      if (user == null)
        response.Data = "User does not exits";

      if (result.Succeeded)
      {
        response.Success = true;
        response.Data = CreateToken(user).Result;
      }
      else
      {
        response.Success = false;
        response.Data = "Password or email does not match";
      }

      return response;
    }

    public async Task<ServiceResponse<string>> Register(User user, string password)
    {
      ServiceResponse<string> response = new ServiceResponse<string>();
      var result = await _userManager.CreateAsync(user, password);

      if (result.Succeeded)
      {
        response.Success = true;
        response.Data = "User Successfully created";
      }

      return response;
    }

    public async Task<bool> UserExists(string username)
    {
      if (await _context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower()))
      {
        return true;
      }
      return false;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
      {
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < computedHash.Length; i++)
        {
          if (computedHash[i] != passwordHash[i])
          {
            return false;
          }
        }
        return true;
      }
    }


    private async Task<string> CreateToken(User user)
    {
      List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName)
        };

      var roles = await _userManager.GetRolesAsync(user);

      foreach (var role in roles)
      {
        claims.Add(new Claim(ClaimTypes.Role, role));
      }

      SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Appsettings:Token").Value));
      SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

      SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(1),
        SigningCredentials = creds
      };

      JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
      SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

      return tokenHandler.WriteToken(token);
    }
  }
}