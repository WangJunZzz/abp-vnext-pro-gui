using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lion.CodeGenerator.EntityFrameworkCore.BusinessLines;
using Lion.CodeGenerator.EnumModels;
using Lion.CodeGenerator.EnumModels.Aggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lion.CodeGenerator.EntityFrameworkCore.EnumModels;

public class EfCoreEnumModelRepository : EfCoreRepository<ICodeGeneratorDbContext, EnumModel, Guid>,
    IEnumModelRepository
{
    public EfCoreEnumModelRepository(IDbContextProvider<ICodeGeneratorDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }
    
    public async Task<List<EnumModel>> ListAsync(Guid aggregateModelId, bool includeDetails = true)
    {
        return await (await GetDbSetAsync()).IncludeDetails(includeDetails)
            .Where(e => e.AggregateModelId == aggregateModelId).ToListAsync();
    }

    public async Task<EnumModel> FindAsync(Guid aggregateModelId, string code, bool includeDetails = true)
    {
        return await (await GetDbSetAsync()).IncludeDetails(includeDetails)
            .FirstOrDefaultAsync(e => e.AggregateModelId == aggregateModelId && e.Code == code);

    }

    public override async Task<IQueryable<EnumModel>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}