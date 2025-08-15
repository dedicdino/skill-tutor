using AutoMapper;
using SkillTutor.Api.Models.Authentication;
using SkillTutor.Domain.Commands;
using SkillTutor.Domain.DTO;

namespace SkillTutor.Api.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LoginDTO, LoginResponse>();
            
        CreateMap<LoginRequest, LoginCommand>();
    }
}