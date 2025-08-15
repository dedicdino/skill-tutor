using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SkillTutor.Application.Abstractions.Interfaces;
using SkillTutor.Domain.Commands;
using SkillTutor.Domain.DTO;
using SkillTutor.Infrastructure.Persistence.Entities;

namespace SkillTutor.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IConfiguration _configuration;
    private readonly SkillTutorDbContext _dbContext;
    private readonly UserManager<User> _userManager;
    
    public UserRepository(
        IConfiguration configuration, 
        SkillTutorDbContext dbContext,
        UserManager<User> userManager)
    {
        _configuration = configuration;
        _dbContext = dbContext;
        _userManager = userManager;
    }
    
    public async Task<LoginDTO?> AuthenticateAsync(LoginCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Username) || string.IsNullOrWhiteSpace(command.Password))
            return null;
        
        var user = await _userManager.FindByNameAsync(command.Username);
        if (user is null)
            return null;

        var passwordValid = await _userManager.CheckPasswordAsync(user, command.Password);
        if (!passwordValid)
            return null;

        // Resolve issuer/audience from arrays or single values
        var issuers = _configuration.GetSection("JwtConfig:Issuers").Get<string[]?>();
        var audiences = _configuration.GetSection("JwtConfig:Audiences").Get<string[]?>();
        var issuer = issuers != null && issuers.Length > 0
            ? issuers[0]
            : _configuration["JwtConfig:Issuer"];
        var audience = audiences != null && audiences.Length > 0
            ? audiences[0]
            : _configuration["JwtConfig:Audience"];
        var key = _configuration["JwtConfig:Key"];
        var tokenValidityMins = _configuration.GetValue<int>("JwtConfig:TokenValidityMins");
        var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(tokenValidityMins);

        var roles = await _userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
            new Claim(JwtRegisteredClaimNames.Name, user.UserName ?? string.Empty)
        };
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = issuer,
            Audience = audience,
            Expires = tokenExpiryTimeStamp,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!)), 
                SecurityAlgorithms.HmacSha512Signature)
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var accessToken = tokenHandler.WriteToken(securityToken);

        return new LoginDTO
        {
            Username = command.Username,
            Token = accessToken,
            ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.UtcNow).TotalSeconds
        };
    }
}