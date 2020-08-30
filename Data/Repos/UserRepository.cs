using System.Collections.Generic;
using System.Linq;
using BlogApi.Data;
using BlogApi.Models;
using simple_cms.Data.Interfaces;

namespace simple_cms.Data.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User GetUser(int id)
        {
           return _context.Users.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<User> GetUserBlogPosts(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<User> GetUserComments(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<User> GetUsers()
        {
            throw new System.NotImplementedException();
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(c => c.Id == id);
        }
    }
}