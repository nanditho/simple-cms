using System.Collections.Generic;
using BlogApi.Models;

namespace simple_cms.Data.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        ICollection<User> GetUserBlogPosts(int id);
        ICollection<User> GetUserComments(int id); 
        bool UserExists(int id);
    }
}