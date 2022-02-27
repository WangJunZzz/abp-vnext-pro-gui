using System.Threading.Tasks;
using Lion.AbpPro.Extension.Customs.Dtos;
using Lion.CodeGenerator.AggregateModels.Dto;

namespace Lion.CodeGenerator.AggregateModels;

public class AggregateModelAppService : CodeGeneratorAppService, IAggregateModelAppService
{
    private readonly AggregateModelManager _aggregateModelManager;

    public AggregateModelAppService(AggregateModelManager aggregateModelManager)
    {
        _aggregateModelManager = aggregateModelManager;
    }

    public async Task CreateAsync(CreateAggregateModelInput input)
    {
        await _aggregateModelManager.CreateAsync(input.BusinessLineId, input.BusinessProjectId, input.Code, input.Description);
    }

    public async Task DeleteAsync(IdInput input)
    {
        await _aggregateModelManager.DeleteAsync(input.Id);
    }

    public async Task UpdateAsync(UpdateAggregateModelInput input)
    {
        await _aggregateModelManager.UpdateAsync(input.Id, input.Code, input.Description);
    }

    public async Task CreateAggregatePropertyAsync(CreateAggregatePropertyInput input)
    {
        await _aggregateModelManager.CreateAggregatePropertyAsync(input.AggregateId, input.Code, input.Description, input.IsRequired, input.Type,
            input.EnumModelId, input.StringMaxLength, input.DecimalPrecision, input.DecimalScale);
    }

    public async Task DeleteAggregatePropertyAsync(DeleteAggregatePropertyInput input)
    {
        await _aggregateModelManager.DeleteAggregatePropertyAsync(input.AggregateId, input.AggregatePropertyId);
    }

    public async Task UpdateAggregatePropertyAsync(UpdateAggregatePropertyInput input)
    {
        await _aggregateModelManager.UpdateAggregatePropertyAsync(input.AggregateId, input.AggregatePropertyId, input.Code, input.Description,
            input.IsRequired,
            input.Type, input.EnumModelId, input.StringMaxLength, input.DecimalPrecision, input.DecimalScale);
    }

    public async Task CreateAggregateEntityAsync(CreateAggregateEntityInput input)
    {
        await _aggregateModelManager.CreateAggregateEntityAsync(input.AggregateId, input.Code, input.Description, input.RelationType);
    }

    public async Task DeleteAggregateEntityAsync(DeleteAggregateEntityInput input)
    {
        await _aggregateModelManager.DeleteAggregateEntityAsync(input.AggregateId, input.AggregateEntityId);
    }

    public async Task UpdateAggregateEntityAsync(UpdateAggregateEntityInput input)
    {
        await _aggregateModelManager.UpdateAggregateEntityAsync(input.AggregateId, input.AggregateEntityId, input.Code, input.Description,
            input.RelationType);
    }

    public async Task CreateAggregateEntityPropertyAsync(CreateAggregateEntityPropertyInput input)
    {
        await _aggregateModelManager.CreateAggregateEntityPropertyAsync(
            input.AggregateId,
            input.AggregateEntityId,
            input.Code,
            input.Description,
            input.IsRequired,
            input.Type,
            input.EnumModelId,
            input.StringMaxLength,
            input.DecimalPrecision,
            input.DecimalScale);
    }

    public async Task DeleteAggregateEntityPropertyAsync(DeleteAggregateEntityPropertyInput input)
    {
        await _aggregateModelManager.DeleteAggregateEntityPropertyAsync(input.AggregateId, input.AggregateEntityId, input.AggregateEntityPropertyId);
    }

    public async Task UpdateAggregateEntityPropertyAsync(UpdateAggregateEntityPropertyInput input)
    {
        await _aggregateModelManager.UpdateAggregateEntityPropertyAsync(input.AggregateId,
            input.AggregateEntityId,
            input.AggregateEntityPropertyId,
            input.Code,
            input.Description,
            input.IsRequired,
            input.Type,
            input.EnumModelId,
            input.StringMaxLength,
            input.DecimalPrecision,
            input.DecimalScale);
    }
}