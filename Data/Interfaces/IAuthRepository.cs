using System.Threading.Tasks;
using BlogApi.Models;

namespace BlogApi.Data.Interfaces
{
  public interface IAuthRepository
  {
    Task<ServiceResponse<string>> Register(User user, string password);
    Task<ServiceResponse<string>> Login(string user, string password);
    Task<bool> UserExists(string username);
  }
}