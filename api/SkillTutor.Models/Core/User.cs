using Microsoft.AspNetCore.Identity;

namespace SkillTutor.Models.Core;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}