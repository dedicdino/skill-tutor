using SkillTutor.Application.Abstractions.Interfaces;
using SkillTutor.Application.Interfaces;
using SkillTutor.Domain.Commands;
using SkillTutor.Domain.DTO;

namespace SkillTutor.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public UserService(
        IUserRepository userRepository,
        IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<LoginDTO?> LoginAsync(LoginCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Username) || string.IsNullOrWhiteSpace(command.Password))
            return null;

        var user = await _userRepository.GetUserByUsernameAsync(command.Username);
        if (user is null)
            return null;

        var passwordValid = await _userRepository.ValidatePasswordAsync(command.Username, command.Password);
        if (!passwordValid)
            return null;

        var roles = await _userRepository.GetUserRolesAsync(command.Username);

        return _jwtService.GenerateToken(user, roles);
    }
}