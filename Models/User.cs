using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BlogApi.Models
{
  public class User : IdentityUser<int>
  {
    public virtual Country Country { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public ICollection<BlogUser> BlogUser { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
  }
}