using System;
using System.Collections.Generic;
using BlogApi.Models;

namespace BlogApi.Dtos.Blog
{
  public class BlogDto
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime DatePublished { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
  }
}