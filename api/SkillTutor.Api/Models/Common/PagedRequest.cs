namespace SkillTutor.Api.Models.Common;

public class PagedRequest
{
    public int Start { get; set; }
    public int Length { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}