using System.Collections.Generic;
using System.Linq;
using BlogApi.Data;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<BlogUser> GetUserBlogPosts(int id)
        {
            return _context.Users.Where(c => c.Id == id).SelectMany(c => c.BlogUser);
        }

        public IQueryable<Comment> GetUserComments(int id)
        {
            return _context.Users.Where(c => c.Id == id).SelectMany(c => c.Comments);
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(c => c.Id).ToList();
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(c => c.Id == id);
        }
    }
}