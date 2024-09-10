using TasteTrailData.Core.Filters.Enums;
using TasteTrailData.Core.Filters.Specifications;
using TasteTrailData.Infrastructure.Filters;
using TasteTrailUserManager.Core.Users.Models;

namespace TasteTrailUserManager.Infrastructure.Common.Admin.Factories;

public class UserManipulationsFilterFactory
{
    public static IFilterSpecification<User>? CreateFilter(FilterType? filterType)
    {
        if (filterType is null)
            return null;

        return filterType switch
        {
            FilterType.NotBanned => new NotBannedFilter<User>(),
            FilterType.Banned => new BannedFilter<User>(),
            FilterType.NotMuted => new NotMutedFilter<User>(),
            FilterType.Muted => new MutedFilter<User>(),
            _ => throw new ArgumentException("Invalid filter type", filterType.ToString())
        };
    }

}