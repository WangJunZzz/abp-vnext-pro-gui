using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Lion.CodeGenerator.AggregateModels;

public class AggregateModelManager : DomainService
{
    private readonly IAggregateModelRepository _aggregateModelRepository;

    public AggregateModelManager(IAggregateModelRepository aggregateModelRepository)
    {
        _aggregateModelRepository = aggregateModelRepository;
    }

    public async Task<AggregateModel> FindAsync(string code, Guid businessLineId, Guid businessProjectId, bool includeDetails = true)
    {
        return await _aggregateModelRepository.FindAsync(code, businessLineId, businessProjectId, includeDetails);
    }

    /// <summary>
    /// 创建聚合根
    /// </summary>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task<AggregateModel> CreateAsync(
        Guid businessLineId,
        Guid businessProjectId,
        string code,
        string description,
        Guid? tenantId)
    {
        var aggregate = await FindAsync(code, businessLineId, businessProjectId);
        if (aggregate != null)
        {
            throw new UserFriendlyException($"{code}|{description}聚合根已存在");
        }

        aggregate = new AggregateModel(GuidGenerator.Create(), businessLineId, businessProjectId, code, description, CurrentTenant.Id);
        return await _aggregateModelRepository.InsertAsync(aggregate);
    }

    /// <summary>
    /// 删除聚合根
    /// </summary>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task DeleteAsync(Guid id)
    {
        var aggregate = await _aggregateModelRepository.FindAsync(id);
        if (aggregate == null)
        {
            throw new UserFriendlyException($"聚合根不存在");
        }

        await _aggregateModelRepository.DeleteAsync(aggregate);
    }

    /// <summary>
    /// 更新聚合根
    /// </summary>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task<AggregateModel> UpdateAsync(Guid id, string code, string description)
    {
        var aggregate = await _aggregateModelRepository.FindAsync(id);
        if (aggregate == null)
        {
            throw new UserFriendlyException($"聚合根不存在");
        }

        if (await _aggregateModelRepository.IsExistAsync(id, code, aggregate.BusinessLineId, aggregate.BusinessLineId))
        {
            throw new UserFriendlyException($"聚合根{code}已存在");
        }

        aggregate.UpdateCodeAndDescription(code, description);

        return await _aggregateModelRepository.UpdateAsync(aggregate);
    }

    /// <summary>
    /// 创建聚合根属性
    /// </summary>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task<AggregateModel> CreateAggregatePropertyAsync(
        Guid aggregateId,
        string code,
        string description,
        bool isRequired,
        string type,
        Guid? enumModelId,
        int stringMaxLength,
        int decimalPrecision,
        int decimalScale)
    {
        var aggregate = await _aggregateModelRepository.FindAsync(aggregateId);
        if (aggregate == null)
        {
            throw new UserFriendlyException($"{code}|{description}聚合根不存在");
        }

        aggregate.AddProperty(GuidGenerator.Create(), code, description, isRequired, type, enumModelId, stringMaxLength, decimalPrecision,
            decimalScale);
        return await _aggregateModelRepository.UpdateAsync(aggregate);
    }

    /// <summary>
    /// 删除聚合根属性
    /// </summary>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task DeleteAggregatePropertyAsync(Guid aggregateId, Guid aggregatePropertyId)
    {
        var aggregate = await _aggregateModelRepository.FindAsync(aggregateId);
        if (aggregate == null)
        {
            throw new UserFriendlyException($"聚合根不存在");
        }

        var property = aggregate.Properties.FirstOrDefault(e => e.Id == aggregatePropertyId);
        if (property == null)
        {
            throw new UserFriendlyException($"聚合根属性不存在");
        }

        aggregate.Properties.Remove(property);
        await _aggregateModelRepository.UpdateAsync(aggregate);
    }

    /// <summary>
    /// 更新聚合根属性
    /// </summary>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task UpdatgeAggregatePropertyAsync(
        Guid aggregateId,
        Guid aggregatePropertyId,
        string code,
        string description,
        bool isRequired,
        string type,
        Guid? enumModelId,
        int stringMaxLength,
        int decimalPrecision,
        int decimalScale)
    {
        var aggregate = await _aggregateModelRepository.FindAsync(aggregateId);
        if (aggregate == null)
        {
            throw new UserFriendlyException($"聚合根不存在");
        }

        var property = aggregate.Properties.FirstOrDefault(e => e.Id == aggregatePropertyId);
        if (property == null)
        {
            throw new UserFriendlyException($"聚合根属性不存在");
        }

        if (aggregate.Properties.Any(e => e.Id != aggregatePropertyId && e.Code == code))
        {
            throw new UserFriendlyException($"聚合根属性名重复");
        }

        property.Update(code, description, isRequired, type, enumModelId, stringMaxLength, decimalPrecision, decimalScale);
        await _aggregateModelRepository.UpdateAsync(aggregate);
    }


    /// <summary>
    /// 创建聚合根下实体
    /// </summary>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task<AggregateModel> CreateAggregateEntityAsync(
        Guid aggregateId,
        string code,
        string description,
        RelationType relationType)
    {
        var aggregate = await _aggregateModelRepository.FindAsync(aggregateId);
        if (aggregate == null)
        {
            throw new UserFriendlyException($"{code}|{description}聚合根不存在");
        }

        if (aggregate.EntityModels.Any(e => e.Code == code))
        {
            throw new UserFriendlyException($"{aggregate.Code}聚合根下{code}实体已存在");
        }

        aggregate.AddEntity(GuidGenerator.Create(), code, description, relationType);

        return await _aggregateModelRepository.UpdateAsync(aggregate);
    }

    /// <summary>
    /// 删除聚合根下实体
    /// </summary>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task<AggregateModel> DeleteAggregateEntityAsync(Guid aggregateId, Guid aggregateEntityId)
    {
        var aggregate = await _aggregateModelRepository.FindAsync(aggregateId);
        if (aggregate == null)
        {
            throw new UserFriendlyException($"聚合根不存在");
        }

        var model = aggregate.EntityModels.FirstOrDefault(e => e.Id == aggregateEntityId);
        if (model == null)
        {
            throw new UserFriendlyException($"实体不存在");
        }

        aggregate.EntityModels.Remove(model);

        return await _aggregateModelRepository.UpdateAsync(aggregate);
    }

    /// <summary>
    /// 更新聚合根下实体
    /// </summary>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task<AggregateModel> UpdateAggregateEntityAsync(
        Guid aggregateId,
        Guid aggregateEntityId,
        string code,
        string description,
        RelationType relationType)
    {
        var aggregate = await _aggregateModelRepository.FindAsync(aggregateId);
        if (aggregate == null)
        {
            throw new UserFriendlyException($"聚合根不存在");
        }

        var model = aggregate.EntityModels.FirstOrDefault(e => e.Id == aggregateEntityId);
        if (model == null)
        {
            throw new UserFriendlyException($"实体不存在");
        }

        if (aggregate.EntityModels.Any(e => e.Id != aggregateEntityId && e.Code == code))
        {
            throw new UserFriendlyException($"实体名已存在");
        }

        model.Update(code, description, relationType);
        return await _aggregateModelRepository.UpdateAsync(aggregate);
    }

    public async Task<AggregateModel> CreateAggregateEntityPropertyAsync(
        Guid aggregateModelId,
        Guid aggregateModelEntityId,
        string code,
        string description,
        bool isRequired,
        string type,
        Guid? enumModelId,
        int stringMaxLength,
        int decimalPrecision,
        int decimalScale)
    {
        var aggregate = await _aggregateModelRepository.FindAsync(aggregateModelId);
        if (aggregate == null)
        {
            throw new UserFriendlyException($"{code}|{description}聚合根不存在");
        }

        var entity = aggregate.EntityModels.FirstOrDefault(e => e.Id == aggregateModelEntityId);
        if (entity == null)
        {
            throw new UserFriendlyException($"{aggregate.Code}聚合根下实体不存在");
        }

        entity.AddProperty(GuidGenerator.Create(), code, description, isRequired, type, enumModelId, stringMaxLength, decimalPrecision, decimalScale);

        return await _aggregateModelRepository.UpdateAsync(aggregate);
    }

    /// <summary>
    /// 删除聚合根下实体的属性
    /// </summary>
    public async Task<AggregateModel> DeleteAggregateEntityPropertyAsync(
        Guid aggregateId,
        Guid aggregateEntityId,
        Guid aggregateEntityPropertyId
    )
    {
        var aggregate = await _aggregateModelRepository.FindAsync(aggregateId);
        if (aggregate == null)
        {
            throw new UserFriendlyException($"聚合根不存在");
        }

        var entity = aggregate.EntityModels.FirstOrDefault(e => e.Id == aggregateEntityId);
        if (entity == null)
        {
            throw new UserFriendlyException($"{aggregate.Code}聚合根下实体不存在");
        }

        var property = entity.Properties.FirstOrDefault(e => e.Id == aggregateEntityPropertyId);

        if (property == null)
        {
            throw new UserFriendlyException($"{entity.Code}实体下属性不存在");
        }

        entity.Properties.Remove(property);
        return await _aggregateModelRepository.UpdateAsync(aggregate);
    }

    /// <summary>
    /// 更新聚合根下实体的属性
    /// </summary>
    public async Task<AggregateModel> UpdateAggregateEntityPropertyAsync(
        Guid aggregateId,
        Guid aggregateEntityId,
        Guid aggregateEntityPropertyId,
        string code,
        string description,
        bool isRequired,
        string type,
        Guid? enumModelId,
        int stringMaxLength,
        int decimalPrecision,
        int decimalScale
    )
    {
        var aggregate = await _aggregateModelRepository.FindAsync(aggregateId);
        if (aggregate == null)
        {
            throw new UserFriendlyException($"聚合根不存在");
        }

        var entity = aggregate.EntityModels.FirstOrDefault(e => e.Id == aggregateEntityId);
        if (entity == null)
        {
            throw new UserFriendlyException($"{aggregate.Code}聚合根下实体不存在");
        }

        var property = entity.Properties.FirstOrDefault(e => e.Id == aggregateEntityPropertyId);

        if (property == null)
        {
            throw new UserFriendlyException($"{entity.Code}实体下属性不存在");
        }

        if (entity.Properties.Any(e => e.Id != aggregateEntityPropertyId && e.Code == code))
        {
            throw new UserFriendlyException($"实体属性名重复");
        }

        property.Update(code, description, isRequired, type, enumModelId, stringMaxLength, decimalPrecision, decimalScale);
        return await _aggregateModelRepository.UpdateAsync(aggregate);
    }
}