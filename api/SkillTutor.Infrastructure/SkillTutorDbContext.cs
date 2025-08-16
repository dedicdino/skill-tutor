using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkillTutor.Infrastructure.Persistence.Entities;

namespace SkillTutor.Infrastructure;

public class SkillTutorDbContext(DbContextOptions<SkillTutorDbContext> options) : IdentityDbContext<User>(options)
{
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