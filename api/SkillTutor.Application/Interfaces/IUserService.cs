using SkillTutor.Domain.Commands;
using SkillTutor.Domain.DTO;

namespace SkillTutor.Application.Interfaces;

public interface IUserService
{
    Task<LoginDTO?> LoginAsync(LoginCommand command);
}