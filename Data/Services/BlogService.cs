using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogApi.Data.Interfaces;
using BlogApi.Dtos.Blog;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Data.Services
{
  public class BlogService : IBlogService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public BlogService(IMapper mapper, DataContext context)
    {
      _context = context;
      _mapper = mapper;

    }

    public async Task<ServiceResponse<List<GetBlogDto>>> AddBlog(AddBlogDto addBlog)
    {
      ServiceResponse<List<GetBlogDto>> serviceResponse = new ServiceResponse<List<GetBlogDto>>();
      Blog blog = _mapper.Map<Blog>(addBlog);
      await _context.Blogs.AddAsync(blog);
      await _context.SaveChangesAsync();
      serviceResponse.Data = (_context.Blogs.Select(c => _mapper.Map<GetBlogDto>(c))).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetBlogDto>>> GetAllBlogs()
    {
      ServiceResponse<List<GetBlogDto>> serviceResponse = new ServiceResponse<List<GetBlogDto>>();
      List<Blog> dbBlogs = await _context.Blogs.ToListAsync();
      serviceResponse.Data = (dbBlogs.Select(x => _mapper.Map<GetBlogDto>(x))).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetBlogDto>> GetBlogById(int id)
    {
      ServiceResponse<GetBlogDto> serviceResponse = new ServiceResponse<GetBlogDto>();
      Blog dbBlog = await _context.Blogs.FirstOrDefaultAsync(x => x.Id == id);
      serviceResponse.Data = _mapper.Map<GetBlogDto>(dbBlog);
      return serviceResponse;
    }
  }
}