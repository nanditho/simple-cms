using AutoMapper;
using BlogApi.Dtos.Blog;
using BlogApi.Models;

namespace BlogApi
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Blog, GetBlogDto>();
      CreateMap<AddBlogDto, Blog>();
    }
  }
}