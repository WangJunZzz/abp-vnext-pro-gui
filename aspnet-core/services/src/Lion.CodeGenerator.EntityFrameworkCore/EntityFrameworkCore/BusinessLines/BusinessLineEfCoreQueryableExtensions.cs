using System.Linq;
using Lion.CodeGenerator.BusinessLines.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Lion.CodeGenerator.EntityFrameworkCore.BusinessLines;

public static class BusinessLineEfCoreQueryableExtensions
{
    public static IQueryable<BusinessLine> IncludeDetails(this IQueryable<BusinessLine> queryable,
        bool include = true)
    {
        return !include ? queryable : queryable.Include(x => x.BusinessProjects);
    }
}