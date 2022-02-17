using System.Linq;
using Lion.CodeGenerator.AggregateModels;
using Lion.CodeGenerator.BusinessLines.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Lion.CodeGenerator.EntityFrameworkCore.BusinessLines;

public static class AggregateModelEfCoreQueryableExtensions
{
    public static IQueryable<AggregateModel> IncludeDetails(this IQueryable<AggregateModel> queryable,
        bool include = true)
    {
        return !include ? queryable : queryable.Include(x => x.Properties).Include(e => e.EntityModels);
    }
}