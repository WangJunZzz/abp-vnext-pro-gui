using Lion.AbpPro.Extension.Customs.Dtos;
using Lion.CodeGenerator.BusinessLines.Aggregates;
using Lion.CodeGenerator.BusinessLines.Dtos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;

namespace Lion.CodeGenerator.BusinessLines;

public class BusinessLineManager : CodeGeneratorDomainService
{
    private readonly IBusinessLineRepository _businessLineRepository;

    public BusinessLineManager(IBusinessLineRepository businessLineRepository)
    {
        _businessLineRepository = businessLineRepository;
    }

    /// <summary>
    /// 创建业务线
    /// </summary>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task<BusinessLineDto> CreateBusinessLineAsync(string name, string description)
    {
        var entity = await _businessLineRepository.FindByNameAsync(name);
        if (entity != null) throw new UserFriendlyException("业务线已存在");
        entity = new BusinessLine(GuidGenerator.Create(), name, true, description, CurrentTenant.Id);

        return ObjectMapper.Map<BusinessLine, BusinessLineDto>(await _businessLineRepository.UpdateAsync(entity));
    }

    /// <summary>
    ///修改业务线
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="enable"></param>
    /// <returns></returns>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task<BusinessLineDto> UpdateBusinessLineAsync(string name, string description, bool enable)
    {
        var entity = await _businessLineRepository.FindAsync(b => b.Name != name);
        if (entity != null) throw new UserFriendlyException("业务线已存在");

        entity.SetTenantId(CurrentTenant.Id);
        entity.SetName(name);
        entity.SetDescription(description);
        entity.SetEnable(enable);

        return ObjectMapper.Map<BusinessLine, BusinessLineDto>(await _businessLineRepository.UpdateAsync(entity));
    }

    /// <summary>
    /// 删除业务线
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _businessLineRepository.GetAsync(id);
        if (entity != null) throw new UserFriendlyException("业务线已存在");

        await _businessLineRepository.DeleteAsync(entity);
    }

    /// <summary>
    /// 分页查询业务线
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="pageSize"></param>
    /// <param name="skipCount"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CustomePagedResultDto<BusinessLineDto>> GetPagedListAsync(
              string filter = null,
              int pageSize = 10,
              int skipCount = 0,
              CancellationToken cancellationToken = default)
    {

        var result = new CustomePagedResultDto<BusinessLineDto>();

        var totalCount = await _businessLineRepository.GetPagedCountAsync(filter, cancellationToken);
        result.TotalCount = totalCount;
        if (totalCount <= 0)
        {
            return result;
        }

        var businessLines = await _businessLineRepository.GetPagedListAsync(skipCount, pageSize, filter, cancellationToken: cancellationToken);
        result.Items = ObjectMapper.Map<List<BusinessLine>, List<BusinessLineDto>>(businessLines);

        return result;
    }

    /// <summary>
    /// 创建业务线下项目
    /// </summary>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task<BusinessProjectDto> CreateBusinessProjectAsync(
        Guid businessLineId, string name, string nameSpace, string description)
    {
        var entity = await _businessLineRepository.FindAsync(businessLineId);
        if (entity == null) throw new UserFriendlyException("业务线不存在");
        entity.AddBusinessProject(GuidGenerator.Create(), businessLineId, name, nameSpace, true, description);

        var bsinessProject = await _businessLineRepository.UpdateAsync(entity);

        return ObjectMapper.Map<BusinessLine, BusinessProjectDto>(bsinessProject);
    }
}