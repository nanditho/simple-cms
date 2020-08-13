using System.Collections.Generic;
using System.Threading.Tasks;
using BlogApi.Dtos.Blog;
using BlogApi.Models;

namespace BlogApi.Data.Interfaces
{
  public interface IBlogService
  {
    Task<ServiceResponse<List<GetBlogDto>>> GetAllBlogs();
    Task<ServiceResponse<GetBlogDto>> GetBlogById(int id);
    Task<ServiceResponse<List<GetBlogDto>>> AddBlog(AddBlogDto addBlog);
  }
}