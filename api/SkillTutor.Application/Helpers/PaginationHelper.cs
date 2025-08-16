using SkillTutor.Domain.Common;

namespace SkillTutor.Application.Helpers;

public static class PaginationHelper
{
    public static PagedResult<T> Paginate<T>(IEnumerable<T> items, int start, int length)
    {
        var itemsList = items.ToList();
        var totalCount = itemsList.Count;
        
        var pagedItems = itemsList
            .Skip(start)
            .Take(length)
            .ToList();
        
        return new PagedResult<T>
        {
            Items = pagedItems,
            TotalCount = totalCount
        };
    }
}
