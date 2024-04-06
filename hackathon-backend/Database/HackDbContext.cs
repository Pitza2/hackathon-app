using Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class HackDbContext : IdentityDbContext<User, Role, string>
{
    public HackDbContext()
    {
    }
    
    public HackDbContext(DbContextOptions<HackDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().ToTable("AuthUser");
        modelBuilder.Entity<Role>().ToTable("AuthRole");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AuthUserRole");
    }
}