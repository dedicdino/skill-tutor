using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTutor.Api.Models.Common;
using SkillTutor.Api.Models.Requests;
using SkillTutor.Api.Models.Responses;
using SkillTutor.Api.Services;
using SkillTutor.Application.Interfaces;
using SkillTutor.Domain.Constants;
using SkillTutor.Domain.Queries;

namespace SkillTutor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(
    IUserService userService,
    IMapper mapper,
    IValidatorService validatorService) : Controller
{
    [Authorize(Roles = Roles.Administrator)]
    [HttpPost("Users")]
    public async Task<ActionResult<PagedResponse<UserResponse>>> GetUsers([FromBody] UsersRequest request)
    {
        var validation = await validatorService.ValidateAsync(request);
        if (!validation.IsValid)
        {
            return BadRequest(
                validation.Errors.Select(error => error.ErrorMessage));
        }
        
        var result = await userService.GetUsersAsync(
            mapper.Map<UsersQuery>(request));
        return Ok(
            mapper.Map<PagedResponse<UserResponse>>(result));
    }
}