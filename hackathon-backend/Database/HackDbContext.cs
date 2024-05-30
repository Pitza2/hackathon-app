using Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class HackDbContext : IdentityDbContext<User>
{ 
    public DbSet<Domain> Domains { get; set; }
    public DbSet<Issue> Issues { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<MentorProfile> MentorProfiles { get; set; }
    public DbSet<ParticipantProfile> ParticipantProfiles { get; set; }
    public HackDbContext(DbContextOptions<HackDbContext> options) : base(options)
    {
    }
    public HackDbContext(){}

}