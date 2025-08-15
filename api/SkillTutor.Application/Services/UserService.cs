using SkillTutor.Application.Abstractions.Interfaces;
using SkillTutor.Application.Interfaces;
using SkillTutor.Domain.Commands;
using SkillTutor.Domain.DTO;

namespace SkillTutor.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<LoginDTO?> LoginAsync(LoginCommand command)
    {
        return await _userRepository.AuthenticateAsync(command);
    }
}