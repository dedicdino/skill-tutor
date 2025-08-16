using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkillTutor.Application.Abstractions.Interfaces;
using SkillTutor.Domain.DTO;
using SkillTutor.Infrastructure.Persistence.Entities;
using AutoMapper;

namespace SkillTutor.Infrastructure.Repositories;

public class UserRepository(
    SkillTutorDbContext dbContext,
    UserManager<User> userManager,
    IMapper mapper)
    : IUserRepository
{
    private readonly SkillTutorDbContext _dbContext = dbContext;

    public async Task<UserDTO?> GetUserByUsernameAsync(string username)
    {
        var user = await userManager.FindByNameAsync(username);
        if (user == null) return null;
        
        return mapper.Map<UserDTO>(user);
    }

    public async Task<bool> ValidatePasswordAsync(string username, string password)
    {
        var user = await userManager.FindByNameAsync(username);
        if (user == null) return false;
        
        return await userManager.CheckPasswordAsync(user, password);
    }

    public async Task<IList<string>> GetUserRolesAsync(string username)
    {
        var user = await userManager.FindByNameAsync(username);
        if (user == null) return new List<string>();
        
        return await userManager.GetRolesAsync(user);
    }

    public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
    {
        var users = await userManager.Users.ToListAsync();
        return mapper.Map<IEnumerable<UserDTO>>(users);
    }
}