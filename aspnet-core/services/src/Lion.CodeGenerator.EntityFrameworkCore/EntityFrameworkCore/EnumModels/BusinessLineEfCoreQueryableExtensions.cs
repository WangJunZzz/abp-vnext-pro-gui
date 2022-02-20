using System.Linq;
using Lion.CodeGenerator.BusinessLines.Aggregates;
using Lion.CodeGenerator.EnumModels;
using Microsoft.EntityFrameworkCore;

namespace Lion.CodeGenerator.EntityFrameworkCore.BusinessLines;

public static class EnumModelEfCoreQueryableExtensions
{
    public static IQueryable<EnumModel> IncludeDetails(this IQueryable<EnumModel> queryable,
        bool include = true)
    {
        return !include ? queryable : queryable.Include(x => x.EnumProperties);
    }
}