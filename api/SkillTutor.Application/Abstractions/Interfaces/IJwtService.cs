using SkillTutor.Domain.DTO;

namespace SkillTutor.Application.Abstractions.Interfaces;

public interface IJwtService
{
    LoginDTO GenerateToken(UserDTO user, IList<string> roles);
}
