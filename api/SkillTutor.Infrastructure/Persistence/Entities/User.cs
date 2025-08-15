using Microsoft.AspNetCore.Identity;

namespace SkillTutor.Infrastructure.Persistence.Entities;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public byte[]? Image { get; set; }
}


