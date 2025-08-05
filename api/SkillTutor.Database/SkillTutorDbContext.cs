using Microsoft.EntityFrameworkCore;

namespace SkillTutor.Database;

public class SkillTutorDbContext : DbContext
{
    public SkillTutorDbContext(
        DbContextOptions<SkillTutorDbContext> options) 
        : base(options) {}
}