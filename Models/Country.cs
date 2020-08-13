using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApi.Models
{
  public class Country
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [StringLength(10, MinimumLength = 3, ErrorMessage = "Country must be between 3 and 10 characters")]
    public string Name { get; set; }
    public virtual ICollection<User> Users { get; set; }
  }
}