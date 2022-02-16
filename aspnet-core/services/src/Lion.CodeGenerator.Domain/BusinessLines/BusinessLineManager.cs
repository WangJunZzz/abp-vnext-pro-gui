using System;
using System.Threading.Tasks;
using Lion.CodeGenerator.BusinessLines.Aggregates;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Lion.CodeGenerator.BusinessLines;

public class BusinessLineManager : DomainService
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
    public async Task CreateBusinessLineAsync(string name, string description)
    {
        var entity = await _businessLineRepository.FindByNameAsync(name);
        if (entity != null) throw new UserFriendlyException("业务线已存在");
        entity = new BusinessLine(GuidGenerator.Create(), name, true, description, CurrentTenant.Id);
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
        entity.AddBusinessProject(GuidGenerator.Create(), businessLineId, name, nameSpace, true, description);
        await _businessLineRepository.UpdateAsync(entity);
    }
}