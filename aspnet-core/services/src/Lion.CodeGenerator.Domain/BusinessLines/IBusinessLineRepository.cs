using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lion.CodeGenerator.BusinessLines.Aggregates;
using Volo.Abp.Domain.Repositories;

namespace Lion.CodeGenerator.BusinessLines;

public interface IBusinessLineRepository : IRepository<BusinessLine, Guid>
{
    Task<long> GetPagedCountAsync(string filter = null, CancellationToken cancellationToken = default);
    Task<List<BusinessLine>> GetPagedListAsync(
      string filter = null,
      int maxResultCount = 10,
      int skipCount = 0,
      CancellationToken cancellationToken = default);
    Task<BusinessLine> FindByNameAsync(string name, bool includeDetails = true);
}