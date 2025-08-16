using FluentValidation;
using FluentValidation.Results;

namespace SkillTutor.Api.Services;

public class ValidatorService(IServiceProvider serviceProvider) : IValidatorService
{
    public async Task<ValidationResult> ValidateAsync<T>(T request) where T : class
    {
        var validator = serviceProvider.GetService<IValidator<T>>();
        
        if (validator == null)
        {
            return new ValidationResult();
        }

        return await validator.ValidateAsync(request);
    }
}
