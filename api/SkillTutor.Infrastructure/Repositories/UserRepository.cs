using Microsoft.AspNetCore.Identity;
using SkillTutor.Application.Abstractions.Interfaces;
using SkillTutor.Domain.DTO;
using SkillTutor.Infrastructure.Persistence.Entities;
using AutoMapper;

namespace SkillTutor.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SkillTutorDbContext _dbContext;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    
    public UserRepository(
        SkillTutorDbContext dbContext,
        UserManager<User> userManager,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _mapper = mapper;
    }
    
    public async Task<UserDTO?> GetUserByUsernameAsync(string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null) return null;
        
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<bool> ValidatePasswordAsync(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null) return false;
        
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<IList<string>> GetUserRolesAsync(string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null) return new List<string>();
        
        return await _userManager.GetRolesAsync(user);
    }
}