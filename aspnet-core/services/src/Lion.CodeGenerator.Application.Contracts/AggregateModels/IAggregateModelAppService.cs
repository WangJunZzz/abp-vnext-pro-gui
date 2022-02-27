using System.Threading.Tasks;
using Lion.AbpPro.Extension.Customs.Dtos;
using Lion.CodeGenerator.AggregateModels.Dto;
using Volo.Abp.Application.Services;

namespace Lion.CodeGenerator.AggregateModels;

public interface IAggregateModelAppService : IApplicationService
{
    /// <summary>
    /// 创建聚合根
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task CreateAsync(CreateAggregateModelInput input);

    /// <summary>
    /// 删除聚合根
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task DeleteAsync(IdInput input);
    
    /// <summary>
    /// 更新聚合根
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdateAsync(UpdateAggregateModelInput input);
    /// <summary>
    /// 创建聚合根属性
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task CreateAggregatePropertyAsync(CreateAggregatePropertyInput input);

    /// <summary>
    /// 删除聚合根属性
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task DeleteAggregatePropertyAsync(DeleteAggregatePropertyInput input);

    /// <summary>
    /// 更新聚合根属性
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdateAggregatePropertyAsync(UpdateAggregatePropertyInput input);

    /// <summary>
    /// 创建聚合根实体
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task CreateAggregateEntityAsync(CreateAggregateEntityInput input);

    /// <summary>
    /// 删除聚合根实体
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task DeleteAggregateEntityAsync(DeleteAggregateEntityInput input);
    /// <summary>
    /// 更新实体
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdateAggregateEntityAsync(UpdateAggregateEntityInput input);
    /// <summary>
    /// 创建聚合根实体属性
    /// </summary>
    /// <param name="input"></param>`
    /// <returns></returns>
    Task CreateAggregateEntityPropertyAsync(CreateAggregateEntityPropertyInput input);

    /// <summary>
    /// 删除聚合根实体属性
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task DeleteAggregateEntityPropertyAsync(DeleteAggregateEntityPropertyInput input);

    /// <summary>
    /// 更新聚合根实体属性
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdateAggregateEntityPropertyAsync(UpdateAggregateEntityPropertyInput input);
}