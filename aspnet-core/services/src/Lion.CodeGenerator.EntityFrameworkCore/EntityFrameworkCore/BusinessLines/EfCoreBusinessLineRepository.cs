using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lion.CodeGenerator.BusinessLines;
using Lion.CodeGenerator.BusinessLines.Aggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lion.CodeGenerator.EntityFrameworkCore.BusinessLines;

public class EfCoreBusinessLineRepository : EfCoreRepository<ICodeGeneratorDbContext, BusinessLine, Guid>, IBusinessLineRepository
{
    public EfCoreBusinessLineRepository(IDbContextProvider<ICodeGeneratorDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }


    public async Task<BusinessLine> FindByNameAsync(string name, bool includeDetails = true)
    {
        return await (await GetDbSetAsync()).IncludeDetails(includeDetails).FirstOrDefaultAsync(e => e.Name == name);

    }

    public async Task<long> GetPagedCountAsync(string filter = null, CancellationToken cancellationToken = default)
    {
        return await (await GetQueryableAsync())
              .WhereIf(!filter.IsNullOrWhiteSpace(), b => (b.Name.Contains(filter)) || (b.Description.Contains(filter)))
              .CountAsync();
    }

    public async Task<List<BusinessLine>> GetPagedListAsync(
        string filter = null,
        int maxResultCount = 10,
        int skipCount = 0,
        CancellationToken cancellationToken = default)
    {
        return await (await GetQueryableAsync())
            .WhereIf(!filter.IsNullOrWhiteSpace(), b => (b.Name.Contains(filter)) || (b.Description.Contains(filter)))
            .OrderByDescending(b => b.CreationTime)
            .PageBy(skipCount, maxResultCount)
            .ToListAsync(cancellationToken);
    }

    public override async Task<IQueryable<BusinessLine>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}