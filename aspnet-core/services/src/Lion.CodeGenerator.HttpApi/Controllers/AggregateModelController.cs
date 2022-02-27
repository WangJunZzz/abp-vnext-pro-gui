using System.Threading.Tasks;
using Lion.AbpPro.Extension.Customs.Dtos;
using Lion.CodeGenerator.AggregateModels;
using Lion.CodeGenerator.AggregateModels.Dto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Lion.CodeGenerator.Controllers;

[Route("api/aggregate-model")]
public class AggregateModelController : CodeGeneratorController, IAggregateModelAppService
{
    private readonly IAggregateModelAppService _aggregateModelAppService;

    public AggregateModelController(IAggregateModelAppService aggregateModelAppService)
    {
        _aggregateModelAppService = aggregateModelAppService;
    }

    [HttpPost("create")]
    [SwaggerOperation(summary: "创建聚合根", Tags = new[] { "AggregateModels" })]
    public Task CreateAsync(CreateAggregateModelInput input)
    {
        return _aggregateModelAppService.CreateAsync(input);
    }

    [HttpPost("delete")]
    [SwaggerOperation(summary: "删除聚合根", Tags = new[] { "AggregateModels" })]
    public Task DeleteAsync(IdInput input)
    {
        return _aggregateModelAppService.DeleteAsync(input);
    }

    [HttpPost("update")]
    [SwaggerOperation(summary: "更新聚合根", Tags = new[] { "AggregateModels" })]
    public Task UpdateAsync(UpdateAggregateModelInput input)
    {
        return _aggregateModelAppService.UpdateAsync(input);
    }

    [HttpPost("createAggregateProperty")]
    [SwaggerOperation(summary: "创建聚合根属性", Tags = new[] { "AggregateModels" })]
    public Task CreateAggregatePropertyAsync(CreateAggregatePropertyInput input)
    {
        return _aggregateModelAppService.CreateAggregatePropertyAsync(input);
    }

    [HttpPost("deleteAggregateProperty")]
    [SwaggerOperation(summary: "删除聚合根属性", Tags = new[] { "AggregateModels" })]
    public Task DeleteAggregatePropertyAsync(DeleteAggregatePropertyInput input)
    {
        return _aggregateModelAppService.DeleteAggregatePropertyAsync(input);
    }

    [HttpPost("updateAggregateProperty")]
    [SwaggerOperation(summary: "更新聚合根属性", Tags = new[] { "AggregateModels" })]
    public Task UpdateAggregatePropertyAsync(UpdateAggregatePropertyInput input)
    {
        return _aggregateModelAppService.UpdateAggregatePropertyAsync(input);
    }

    [HttpPost("createAggregateEntity")]
    [SwaggerOperation(summary: "创建聚合根实体", Tags = new[] { "AggregateModels" })]
    public Task CreateAggregateEntityAsync(CreateAggregateEntityInput input)
    {
        return _aggregateModelAppService.CreateAggregateEntityAsync(input);
    }

    [HttpPost("deleteAggregateEntity")]
    [SwaggerOperation(summary: "删除聚合根实体", Tags = new[] { "AggregateModels" })]
    public Task DeleteAggregateEntityAsync(DeleteAggregateEntityInput input)
    {
        return _aggregateModelAppService.DeleteAggregateEntityAsync(input);
    }

    [HttpPost("updateAggregateEntity")]
    [SwaggerOperation(summary: "更新实体", Tags = new[] { "AggregateModels" })]
    public Task UpdateAggregateEntityAsync(UpdateAggregateEntityInput input)
    {
        return _aggregateModelAppService.UpdateAggregateEntityAsync(input);
    }

    [HttpPost("createAggregateEntityProperty")]
    [SwaggerOperation(summary: "创建聚合根实体属性", Tags = new[] { "AggregateModels" })]
    public Task CreateAggregateEntityPropertyAsync(CreateAggregateEntityPropertyInput input)
    {
        return _aggregateModelAppService.CreateAggregateEntityPropertyAsync(input);
    }

    [HttpPost("deleteAggregateEntityProperty")]
    [SwaggerOperation(summary: "删除聚合根实体属性", Tags = new[] { "AggregateModels" })]
    public Task DeleteAggregateEntityPropertyAsync(DeleteAggregateEntityPropertyInput input)
    {
        return _aggregateModelAppService.DeleteAggregateEntityPropertyAsync(input);
    }

    [HttpPost("updateAggregateEntityProperty")]
    [SwaggerOperation(summary: "更新聚合根实体属性", Tags = new[] { "AggregateModels" })]
    public Task UpdateAggregateEntityPropertyAsync(UpdateAggregateEntityPropertyInput input)
    {
        return _aggregateModelAppService.UpdateAggregateEntityPropertyAsync(input);
    }
}