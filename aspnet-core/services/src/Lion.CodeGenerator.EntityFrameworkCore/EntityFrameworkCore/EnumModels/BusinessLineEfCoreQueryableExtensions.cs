using System.Linq;
using Lion.CodeGenerator.EnumModels.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Lion.CodeGenerator.EntityFrameworkCore.EnumModels;

public static class EnumModelEfCoreQueryableExtensions
{
    public static IQueryable<EnumModel> IncludeDetails(this IQueryable<EnumModel> queryable,
        bool include = true)
    {
        return !include ? queryable : queryable.Include(x => x.EnumProperties);
    }
}