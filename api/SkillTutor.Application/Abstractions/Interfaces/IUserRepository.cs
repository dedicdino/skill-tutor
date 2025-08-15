using SkillTutor.Domain.Commands;
using SkillTutor.Domain.DTO;

namespace SkillTutor.Application.Abstractions.Interfaces;

public interface IUserRepository
{
    Task<LoginDTO?> AuthenticateAsync(LoginCommand command);
}


