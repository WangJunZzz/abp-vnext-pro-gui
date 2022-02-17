using System;
using System.Linq;
using System.Threading.Tasks;
using Lion.CodeGenerator.BusinessLines;
using Lion.CodeGenerator.BusinessLines.Aggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lion.CodeGenerator.EntityFrameworkCore.BusinessLines;

public class EfCoreBusinessLineRepository: EfCoreRepository<ICodeGeneratorDbContext, BusinessLine, Guid>, IBusinessLineRepository
{
    public EfCoreBusinessLineRepository(IDbContextProvider<ICodeGeneratorDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    
    


    public async Task<BusinessLine> FindByNameAsync(string name, bool includeDetails = true)
    {
        return await (await GetDbSetAsync()).IncludeDetails(includeDetails).FirstOrDefaultAsync(e => e.Name == name);

    }
    
    public override async Task<IQueryable<BusinessLine>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}