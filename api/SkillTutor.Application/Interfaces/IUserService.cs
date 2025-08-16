using SkillTutor.Domain.Commands;
using SkillTutor.Domain.Common;
using SkillTutor.Domain.DTO;
using SkillTutor.Domain.Queries;

namespace SkillTutor.Application.Interfaces;

public interface IUserService
{
    Task<LoginDTO?> LoginAsync(LoginCommand command);
    Task<PagedResult<UserDTO>> GetUsersAsync(UsersQuery query);
}