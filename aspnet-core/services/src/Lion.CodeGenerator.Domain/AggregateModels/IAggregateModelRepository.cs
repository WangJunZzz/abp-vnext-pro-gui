using System;
using System.Threading.Tasks;
using Lion.CodeGenerator.AggregateModels.Aggregates;
using Volo.Abp.Domain.Repositories;

namespace Lion.CodeGenerator.AggregateModels;

public interface IAggregateModelRepository : IRepository<AggregateModel, Guid>
{
    Task<AggregateModel> FindAsync(string code, Guid businessLineId, Guid businessProjectId, bool includeDetails = true);

    /// <summary>
    /// 判断聚合根 code是否 重复
    /// 排除 excludedAggregateModelId 
    /// </summary>
    Task<bool> IsExistAsync(Guid excludedAggregateModelId, string code, Guid businessLineId, Guid businessProjectId);
}