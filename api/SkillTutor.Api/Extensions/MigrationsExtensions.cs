using Microsoft.EntityFrameworkCore;
using SkillTutor.Infrastructure;

namespace SkillTutor.Api.Extensions;

public static class MigrationsExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using SkillTutorDbContext context = scope.ServiceProvider.GetRequiredService<SkillTutorDbContext>();
        context.Database.Migrate();
    }
}