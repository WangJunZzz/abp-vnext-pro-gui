using System;
using System.Threading.Tasks;
using Lion.CodeGenerator.BusinessLines.Aggregates;
using Volo.Abp.Domain.Repositories;

namespace Lion.CodeGenerator.BusinessLines;

public interface IBusinessLineRepository : IRepository<BusinessLine, Guid>
{
    Task<BusinessLine> FindByNameAsync(string name, bool includeDetails = true);
}