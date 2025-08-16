using FluentValidation;
using SkillTutor.Api.Models.Common;

namespace SkillTutor.Api.Validators;

public abstract class PagedRequestValidator<T> : AbstractValidator<T> where T : PagedRequest
{
    protected PagedRequestValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0)
            .NotNull()
            .WithMessage("Page must be greater than 0.");
        
        RuleFor(x => x.PageSize)
            .GreaterThan(0)
            .NotNull()
            .WithMessage("PageSize must be greater than 0.");
        
        RuleFor(x => x.Length)
            .GreaterThan(0)
            .NotNull()
            .WithMessage("Length must be greater than 0.");
    }
}