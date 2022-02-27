using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lion.CodeGenerator.EnumModels.Aggregates;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Lion.CodeGenerator.EnumModels;

public class EnumModelManager : DomainService
{
    private readonly IEnumModelRepository _enumModelRepository;

    public EnumModelManager(IEnumModelRepository enumModelRepository)
    {
        _enumModelRepository = enumModelRepository;
    }

    public async Task<List<EnumModel>> ListAsync(Guid aggregateModelId, bool includeDetails = true)
    {
        return await _enumModelRepository.ListAsync(aggregateModelId, includeDetails);
    }

    /// <summary>
    /// 创建聚合根枚举
    /// </summary>
    public async Task<EnumModel> CreateAsync(Guid aggregateModelId, string code, string description)
    {
        Check.NotNullOrWhiteSpace(code, nameof(code));
        var entity = await _enumModelRepository.FindAsync(aggregateModelId, code);
        if (entity != null)
        {
            throw new UserFriendlyException("当前聚合根下该枚举已存在");
        }

        entity = new EnumModel(GuidGenerator.Create(), aggregateModelId, code, description, CurrentTenant.Id);

        return await _enumModelRepository.InsertAsync(entity);
    }

    /// <summary>
    /// 创建枚举属性
    /// </summary>
    public async Task<EnumModel> CreatePropertyAsync(Guid aggregateModelId, Guid enumModelId,
        string code, string description, int value)
    {
        Check.NotNullOrWhiteSpace(code, nameof(code));
        var entity = await _enumModelRepository.FindAsync(enumModelId);
        if (entity == null)
        {
            throw new UserFriendlyException("当前枚举不存在");
        }


        entity.AddEnumProperty(enumModelId, code, description, value);

        return await _enumModelRepository.UpdateAsync(entity);
    }
}