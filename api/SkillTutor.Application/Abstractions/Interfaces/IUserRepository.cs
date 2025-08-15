using SkillTutor.Domain.DTO;

namespace SkillTutor.Application.Abstractions.Interfaces;

public interface IUserRepository
{
    Task<UserDTO?> GetUserByUsernameAsync(string username);
    Task<bool> ValidatePasswordAsync(string username, string password);
    Task<IList<string>> GetUserRolesAsync(string username);
}


