using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SkillTutor.Infrastructure.Persistence.Entities;

namespace SkillTutor.Infrastructure.Services;

public interface IDatabaseSeeder
{
    Task SeedAsync();
}

public class DatabaseSeeder : IDatabaseSeeder
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ILogger<DatabaseSeeder> _logger;

    public DatabaseSeeder(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ILogger<DatabaseSeeder> logger)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _logger = logger;
    }

    public async Task SeedAsync()
    {
        await SeedDefaultRolesAsync();
        await SeedDefaultUsersAsync();
    }

    private async Task SeedDefaultRolesAsync()
    {
        var roles = new[] { "Administrator", "User" };

        foreach (var roleName in roles)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                var role = new IdentityRole(roleName);
                var result = await _roleManager.CreateAsync(role);
                
                if (result.Succeeded)
                {
                    _logger.LogInformation("Created role: {RoleName}", roleName);
                }
                else
                {
                    _logger.LogError("Failed to create role {RoleName}: {Errors}", 
                        roleName, string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
            else
            {
                _logger.LogInformation("Role {RoleName} already exists, skipping creation", roleName);
            }
        }
    }

    private async Task SeedDefaultUsersAsync()
    {
        var defaultUsers = new[]
        {
            new { Username = "desktop", FirstName = "Desktop", LastName = "User", Password = "test", Role = "Administrator" },
            new { Username = "mobile", FirstName = "Mobile", LastName = "User", Password = "test", Role = "User" }
        };

        foreach (var userData in defaultUsers)
        {
            var existingUser = await _userManager.FindByNameAsync(userData.Username);
            if (existingUser == null)
            {
                var user = new User
                {
                    UserName = userData.Username,
                    FirstName = userData.FirstName,
                    LastName = userData.LastName
                };

                var result = await _userManager.CreateAsync(user, userData.Password);
                if (result.Succeeded)
                {
                    // Assign role to user
                    var roleResult = await _userManager.AddToRoleAsync(user, userData.Role);
                    if (roleResult.Succeeded)
                    {
                        _logger.LogInformation("Created default user: {Username} with role: {Role}", userData.Username, userData.Role);
                    }
                    else
                    {
                        _logger.LogError("Failed to assign role {Role} to user {Username}: {Errors}", 
                            userData.Role, userData.Username, string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                    }
                }
                else
                {
                    _logger.LogError("Failed to create user {Username}: {Errors}", 
                        userData.Username, string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
            else
            {
                // User exists, check if they have the correct role
                var hasRole = await _userManager.IsInRoleAsync(existingUser, userData.Role);
                if (!hasRole)
                {
                    var roleResult = await _userManager.AddToRoleAsync(existingUser, userData.Role);
                    if (roleResult.Succeeded)
                    {
                        _logger.LogInformation("Assigned role {Role} to existing user: {Username}", userData.Role, userData.Username);
                    }
                    else
                    {
                        _logger.LogError("Failed to assign role {Role} to existing user {Username}: {Errors}", 
                            userData.Role, userData.Username, string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                    }
                }
                else
                {
                    _logger.LogInformation("User {Username} already exists with correct role {Role}", userData.Username, userData.Role);
                }
            }
        }
    }
}
