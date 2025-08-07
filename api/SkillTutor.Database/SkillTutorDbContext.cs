using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkillTutor.Models.Core;

namespace SkillTutor.Database;

public class SkillTutorDbContext : IdentityDbContext<User>
{
    public SkillTutorDbContext(
        DbContextOptions<SkillTutorDbContext> options) 
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<User>().Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(30);
        builder.Entity<User>().Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(30);
    }
}