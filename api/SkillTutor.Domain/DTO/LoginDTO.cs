namespace SkillTutor.Domain.DTO;

public class LoginDTO
{
    public string? Username { get; set; }
    public string? Token { get; set; }
    public int ExpiresIn { get; set; }
}