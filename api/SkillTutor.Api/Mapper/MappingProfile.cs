using AutoMapper;
using SkillTutor.Api.Models.Authentication;
using SkillTutor.Api.Models.Common;
using SkillTutor.Api.Models.Requests;
using SkillTutor.Api.Models.Responses;
using SkillTutor.Domain.Commands;
using SkillTutor.Domain.Common;
using SkillTutor.Domain.DTO;
using SkillTutor.Domain.Queries;
using SkillTutor.Infrastructure.Persistence.Entities;

namespace SkillTutor.Api.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LoginDTO, LoginResponse>();
        CreateMap<UserDTO, UserResponse>();
        
        CreateMap(typeof(PagedResult<>), typeof(PagedResponse<>));
        
        CreateMap<LoginRequest, LoginCommand>();
        CreateMap<UsersRequest, UsersQuery>();
        CreateMap<PagedRequest, PagedQuery>();
    }
}