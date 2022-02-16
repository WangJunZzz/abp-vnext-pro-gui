using System;
using Lion.CodeGenerator.BusinessLines.Aggregates;
using Volo.Abp.Domain.Repositories;

namespace Lion.CodeGenerator.BusinessLines;

public interface IBusinessLineRepository : IRepository<BusinessLine, Guid>
{
}