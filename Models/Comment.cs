using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApi.Models
{
  public class Comment
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [StringLength(40, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 10 characters")]
    public string Title { get; set; }
    public string Content { get; set; }
    public virtual User User { get; set; }
    public virtual Blog Blog { get; set; }
  }
}