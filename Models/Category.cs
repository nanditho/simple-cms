using System.Collections.Generic;

namespace BlogApi.Models
{
  public class Category
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<BlogCategory> BlogCategories { get; set; }
  }
}