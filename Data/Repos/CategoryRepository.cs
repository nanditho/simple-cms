using System.Collections.Generic;
using System.Linq;
using BlogApi.Data.Interfaces;
using BlogApi.Models;

namespace BlogApi.Data.Repos
{
  public class CategoryRepository : ICategoryRepository
  {
    private readonly DataContext _context;
    public CategoryRepository(DataContext context)
    {
      _context = context;
    }
    public bool CategoryExists(int category)
    {
      return _context.Categories.Any(c => c.Id == category);
    }

    public ICollection<Blog> GetBlogsForCategory(int categoryId)
    {
      return _context.BlogCategories.Where(c => c.CategoryId == categoryId).Select(b => b.Blog).ToList();
    }

    public ICollection<Category> GetCategories()
    {
      return _context.Categories.OrderBy(c => c.Name).ToList();
    }

    public Category GetCategory(int id)
    {
      return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
    }

    public ICollection<Category> GetAllCategoriesOfBlog(int id)
    {
      return _context.BlogCategories.Where(c => c.BlogId == id).Select(c => c.Category).ToList();

    }
  }
}