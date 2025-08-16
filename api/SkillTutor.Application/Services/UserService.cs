using SkillTutor.Application.Abstractions.Interfaces;
using SkillTutor.Application.Interfaces;
using SkillTutor.Application.Helpers;
using SkillTutor.Domain.Commands;
using SkillTutor.Domain.Common;
using SkillTutor.Domain.DTO;
using SkillTutor.Domain.Queries;

namespace SkillTutor.Application.Services;

public class UserService(
    IUserRepository userRepository,
    IJwtService jwtService) : IUserService
{
    public async Task<LoginDTO?> LoginAsync(LoginCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Username) || string.IsNullOrWhiteSpace(command.Password))
            return null;

        var user = await userRepository.GetUserByUsernameAsync(command.Username);
        if (user is null)
            return null;

        var passwordValid = await userRepository.ValidatePasswordAsync(command.Username, command.Password);
        if (!passwordValid)
            return null;

        var roles = await userRepository.GetUserRolesAsync(command.Username);

        return jwtService.GenerateToken(user, roles);
    }

    public async Task<PagedResult<UserDTO>> GetUsersAsync(UsersQuery query)
    {
        var allUsers = await userRepository.GetAllUsersAsync();
        return PaginationHelper.Paginate(allUsers, query.Start, query.Length);
    }
}