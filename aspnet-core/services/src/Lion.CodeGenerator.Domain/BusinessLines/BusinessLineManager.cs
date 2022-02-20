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
    private readonly IBusinessLineFreeSqlRepository _businessLineFreeSqlRepository;

    public BusinessLineManager(
        IBusinessLineRepository businessLineRepository,
        IBusinessLineFreeSqlRepository businessLineFreeSqlRepository
        )
    {
        _businessLineRepository = businessLineRepository;
        this._businessLineFreeSqlRepository = businessLineFreeSqlRepository;
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

        return ObjectMapper.Map<BusinessLine, BusinessLineDto>(await _businessLineRepository.InsertAsync(entity));
    }

    /// <summary>
    /// 修改业务线
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="enable"></param>
    /// <returns></returns>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task<BusinessLineDto> UpdateBusinessLineAsync(Guid id, string name, string description, bool enable)
    {
        var buisinessLine = await _businessLineRepository.FindAsync(b => b.Id == id);
        if (buisinessLine == null)
        {
            throw new UserFriendlyException($"业务线id:{id}不存在");
        }

        await ChangeNameAsync(buisinessLine, name);

        buisinessLine.UpdateBuisinessLine(CurrentTenant.Id, name, enable, description);

        return ObjectMapper.Map<BusinessLine, BusinessLineDto>(await _businessLineRepository.UpdateAsync(buisinessLine));
    }

    /// <summary>
    /// 删除业务线
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task DeleteAsync(Guid id)
    {
        var buisinessLine = await _businessLineRepository.FindAsync(b => b.Id == id);
        if (buisinessLine == null)
        {
            throw new UserFriendlyException($"业务线id:{id}不存在");
        }

        buisinessLine.BusinessProjects.Clear();
        await _businessLineRepository.DeleteAsync(buisinessLine);
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

        //var result = new CustomePagedResultDto<BusinessLineDto>();

        //var totalCount = await _businessLineRepository.GetPagedCountAsync(filter, cancellationToken);
        //result.TotalCount = totalCount;
        //if (totalCount <= 0)
        //{
        //    return result;
        //}

        //var businessLines = await _businessLineRepository.GetPagedListAsync(filter, pageSize, skipCount, cancellationToken: cancellationToken);
        //result.Items = ObjectMapper.Map<List<BusinessLine>, List<BusinessLineDto>>(businessLines);
        // return result;

        return await _businessLineFreeSqlRepository.PagingAsync(filter, pageSize, skipCount);
    }

    /// <summary>
    /// 创建业务线项目
    /// </summary>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task<BusinessLineDto> CreateBusinessProjectAsync(
        Guid businessLineId, string name, bool enable, string nameSpace, string description)
    {
        var businessLine = await _businessLineRepository.FindAsync(businessLineId);
        if (businessLine == null) throw new UserFriendlyException($"业务线id:{businessLineId}不存在");

        businessLine.AddBusinessProject(GuidGenerator.Create(), businessLineId, name, nameSpace, enable, description);

        businessLine = await _businessLineRepository.UpdateAsync(businessLine);

        return ObjectMapper.Map<BusinessLine, BusinessLineDto>(businessLine);
    }

    /// <summary>
    /// 更新业务线项目
    /// </summary>
    /// <param name="id"></param>
    /// <param name="businessLineId"></param>
    /// <param name="name"></param>
    /// <param name="enable"></param>
    /// <param name="nameSpace"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task<BusinessLineDto> UpdateBusinessProjectAsync(Guid id, Guid businessLineId, string name, bool enable, string nameSpace, string description)
    {
        var businessLine = await _businessLineRepository.FindAsync(b => b.Id == businessLineId);
        if (businessLine == null)
        {
            throw new UserFriendlyException($"业务线id:{businessLineId}不存在");
        }

        businessLine = businessLine.UpdateBusinessProject(id, name, nameSpace, enable, description);

        businessLine = await _businessLineRepository.UpdateAsync(businessLine);

        return ObjectMapper.Map<BusinessLine, BusinessLineDto>(businessLine);
    }

    /// <summary>
    /// 删除业务线项目
    /// </summary>
    /// <param name="buinessLineId"></param>
    /// <param name="buinessProjectId"></param>
    /// <returns></returns>
    /// <exception cref="UserFriendlyException"></exception>
    public async Task DeleteBusinessProjectAsync(Guid buinessLineId, Guid buinessProjectId)
    {
        var businessLine = await _businessLineRepository.FindAsync(b => b.Id == buinessLineId);
        if (businessLine == null)
        {
            throw new UserFriendlyException($"业务线id:{buinessLineId}不存在");
        }

        businessLine = businessLine.RemoveBusinessProject(buinessLineId, buinessProjectId);

        await _businessLineRepository.UpdateAsync(businessLine);
    }

    private async Task ChangeNameAsync(BusinessLine businessLine, string newName)
    {
        Check.NotNull(businessLine, nameof(businessLine));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        var existingBuisnessLine = await _businessLineRepository.FindByNameAsync(newName);
        if (existingBuisnessLine != null && existingBuisnessLine.Id != businessLine.Id)
        {
            throw new UserFriendlyException("业务线已存在");
        }

        businessLine.ChangeName(newName);
    }
}