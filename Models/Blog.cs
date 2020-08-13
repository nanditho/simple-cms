using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApi.Models
{
  public class Blog
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [StringLength(10, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 10 characters")]
    public string Title { get; set; }
    [Required]
    [MaxLength(200, ErrorMessage = "Content cannot be more that 200 characters")]
    public string Content { get; set; }
    public DateTime? DatePublished { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<BlogUser> BlogUser { get; set; }
    public virtual ICollection<BlogCategory> BlogCategories { get; set; }
  }
}