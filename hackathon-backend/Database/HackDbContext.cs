using Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class HackDbContext : IdentityDbContext<User>
{ 
    public DbSet<Domain> Domains { get; set; }
    public DbSet<Issue> Issues { get; set; }
    public DbSet<MentorProfile> MentorProfiles { get; set; }
    public DbSet<ParticipantProfile> ParticipantProfiles { get; set; }
    public DbSet<IssueToDomain> IssuesToDomains { get; set; }
    public DbSet<MentorProfileToDomain> MentorProfilesToDomains { get; set; }
    public HackDbContext(DbContextOptions<HackDbContext> options) : base(options)
    {
    }
    public HackDbContext(){}

}