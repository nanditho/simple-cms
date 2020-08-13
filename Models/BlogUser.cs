using System.ComponentModel.DataAnnotations;

namespace BlogApi.Models
{
  public class BlogUser
  {
    [Key]
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
  }
}