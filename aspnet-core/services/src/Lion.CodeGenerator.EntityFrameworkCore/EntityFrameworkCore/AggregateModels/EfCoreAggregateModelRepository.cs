using System;
using System.Linq;
using System.Threading.Tasks;
using Lion.CodeGenerator.AggregateModels;
using Lion.CodeGenerator.AggregateModels.Aggregates;
using Lion.CodeGenerator.EntityFrameworkCore.BusinessLines;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lion.CodeGenerator.EntityFrameworkCore.AggregateModels;

public class EfCoreAggregateModelRepository : EfCoreRepository<ICodeGeneratorDbContext, AggregateModel, Guid>, IAggregateModelRepository
{
    public EfCoreAggregateModelRepository(IDbContextProvider<ICodeGeneratorDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }


    public async Task<AggregateModel> FindAsync(string code, Guid businessLineId, Guid businessProjectId, bool includeDetails = true)
    {
        return await (await GetDbSetAsync()).IncludeDetails(includeDetails)
            .FirstOrDefaultAsync(e =>
                e.Code == code &&
                e.BusinessLineId == businessLineId &&
                e.BusinessProjectId == businessProjectId);
    }

    public async Task<bool> IsExistAsync(Guid excludedAggregateModelId, string code, Guid businessLineId, Guid businessProjectId)
    {
        return await (await GetDbSetAsync()).AnyAsync(e =>
            e.Id != excludedAggregateModelId && e.Code == code && e.BusinessLineId == businessLineId && e.BusinessProjectId == businessProjectId);
    }

    public override async Task<IQueryable<AggregateModel>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}