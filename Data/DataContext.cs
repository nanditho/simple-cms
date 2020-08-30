using BlogApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Data
{
  public class DataContext : IdentityDbContext<User, Role, int,
   IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
   IdentityRoleClaim<int>, IdentityUserToken<int>>
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public virtual DbSet<Blog> Blogs { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<BlogCategory> BlogCategories { get; set; }
    public virtual DbSet<BlogUser> BlogUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<UserRole>(userRole =>
      {
        userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
        userRole.HasOne(ur => ur.Role)
          .WithMany(r => r.UserRoles)
          .HasForeignKey(ur => ur.RoleId)
          .IsRequired();
        userRole.HasOne(ur => ur.User)
          .WithMany(r => r.UserRoles)
          .HasForeignKey(ur => ur.UserId)
          .IsRequired();
      });

      builder.Entity<BlogCategory>()
        .HasKey(bc => new { bc.BlogId, bc.CategoryId });
      builder.Entity<BlogCategory>()
        .HasOne(b => b.Blog)
        .WithMany(bc => bc.BlogCategories)
        .HasForeignKey(b => b.BlogId);
      builder.Entity<BlogCategory>()
        .HasOne(c => c.Category)
        .WithMany(bc => bc.BlogCategories)
        .HasForeignKey(c => c.CategoryId);

      builder.Entity<BlogUser>()
        .HasKey(bc => new { bc.BlogId, bc.UserId });
      builder.Entity<BlogUser>()
        .HasOne(b => b.User)
        .WithMany(bc => bc.BlogUser)
        .HasForeignKey(b => b.BlogId);
      builder.Entity<BlogUser>()
        .HasOne(c => c.Blog)
        .WithMany(bc => bc.BlogUser)
        .HasForeignKey(c => c.UserId);


    }
  }
}