using System.Collections.Generic;
using System.Linq;
using BlogApi.Models;

namespace simple_cms.Data.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        IQueryable<BlogUser> GetUserBlogPosts(int id);
        IQueryable<Comment> GetUserComments(int id); 
        bool UserExists(int id);
    }
}