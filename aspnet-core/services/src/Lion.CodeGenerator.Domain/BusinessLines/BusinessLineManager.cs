using System;
using System.Threading.Tasks;
using Lion.AbpPro.Extension.Customs.Dtos;
using Lion.CodeGenerator.BusinessLines.Aggregates;
using Lion.CodeGenerator.BusinessLines.Dto;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Lion.CodeGenerator.BusinessLines;

public class BusinessLineManager : DomainService
{
    private readonly IBusinessLineRepository _businessLineRepository;
    private readonly IBusinessLineFreeSqlRepository _businessLineFreeSqlRepository;
    public BusinessLineManager(
        IBusinessLineRepository businessLineRepository,
        IBusinessLineFreeSqlRepository businessLineFreeSqlRepository)
    {
        _businessLineRepository = businessLineRepository;
        _businessLineFreeSqlRepository = businessLineFreeSqlRepository;
    }

    /// <summary>
    /// 分页查询业务线
    /// </summary>
    /// <returns></returns>
    public async Task<CustomePagedResultDto<PagingBusinessLineOutput>> PagingAsync(
        PagingBusinessLineInput input)
    {
        return await _businessLineFreeSqlRepository.PagingAsync(input);
    }
    
    /// <summary>
    /// 创建业务线
    /// </summary>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task CreateBusinessLineAsync(string name, string description)
    {
        var entity = await _businessLineRepository.FindByNameAsync(name);
        if (entity != null) throw new UserFriendlyException("业务线已存在");
        entity = new BusinessLine(GuidGenerator.Create(), name, false, description, CurrentTenant.Id);
        await _businessLineRepository.InsertAsync(entity);
    }

    /// <summary>
    /// 创建业务线下项目
    /// </summary>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task CreateBusinessProjectAsync(Guid businessLineId, string name, string nameSpace, string description)
    {
        var entity = await _businessLineRepository.FindAsync(businessLineId);
        if (entity == null) throw new UserFriendlyException("业务线不存在");
        entity.AddBusinessProject(GuidGenerator.Create(), businessLineId, name, nameSpace, false, description);
        await _businessLineRepository.UpdateAsync(entity);
    }
}