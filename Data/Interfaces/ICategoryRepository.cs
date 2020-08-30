using System.Collections.Generic;
using BlogApi.Models;

namespace BlogApi.Data.Interfaces
{
  public interface ICategoryRepository
  {
    ICollection<Category> GetCategories();
    Category GetCategory(int id);
    ICollection<Category> GetCategoriesOfBlog(int id);
    ICollection<Blog> GetBlogsForCategory(int categoryId);
    bool CategoryExists(int category);
  }
}