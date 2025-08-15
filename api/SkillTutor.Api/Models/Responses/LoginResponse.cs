namespace SkillTutor.Api.Models.Authentication;

public class LoginResponse
{
    public string? Username { get; set; }
    public string? Token { get; set; }
    public int ExpiresIn { get; set; }
}


