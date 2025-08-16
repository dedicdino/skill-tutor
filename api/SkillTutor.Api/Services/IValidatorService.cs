using FluentValidation;
using FluentValidation.Results;

namespace SkillTutor.Api.Services;

public interface IValidatorService
{
    Task<ValidationResult> ValidateAsync<T>(T request) where T : class;
}
