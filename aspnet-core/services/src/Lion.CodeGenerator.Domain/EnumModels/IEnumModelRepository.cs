using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lion.CodeGenerator.EnumModels;

public interface IEnumModelRepository: IRepository<EnumModel, Guid>
{
    /// <summary>
    /// 获取聚合跟下所有枚举
    /// </summary>
    /// <returns></returns>
    Task<List<EnumModel>> ListAsync(Guid aggregateModelId, bool includeDetails = true);

    Task<EnumModel> FindAsync(Guid aggregateModelId, string code,bool includeDetails = true);
}