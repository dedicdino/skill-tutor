namespace SkillTutor.Domain.Common;

public class PagedQuery
{
    public int Start { get; set; }
    public int Length { get; set; } = 10;
    public int Page { get; set; }
    public int PageSize { get; set; } = 10;
}