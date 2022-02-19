using System.Linq;
using Lion.CodeGenerator.AggregateModels.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Lion.CodeGenerator.EntityFrameworkCore.AggregateModels;

public static class AggregateModelEfCoreQueryableExtensions
{
    public static IQueryable<AggregateModel> IncludeDetails(this IQueryable<AggregateModel> queryable,
        bool include = true)
    {
        return !include ? queryable : queryable.Include(x => x.Properties).Include(e => e.EntityModels);
    }
}