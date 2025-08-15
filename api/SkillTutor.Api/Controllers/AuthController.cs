using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTutor.Application.Interfaces;
using SkillTutor.Api.Models.Authentication;
using SkillTutor.Domain.Commands;

namespace SkillTutor.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public AuthController(
        IUserService userService, 
        IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
    {
        var response = await _userService
            .LoginAsync(_mapper.Map<LoginCommand>(request));
        if (response == null)
            return Unauthorized();
        
        return _mapper.Map<LoginResponse>(response);
    }
}