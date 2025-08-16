using SkillTutor.Api.Models.Requests;

namespace SkillTutor.Api.Validators;

internal sealed class UsersRequestValidator : PagedRequestValidator<UsersRequest>
{
    public UsersRequestValidator() : base()
    {
    }
}