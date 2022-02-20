using Lion.AbpPro.Extension.Customs.Dtos;
using Lion.CodeGenerator.BusinessLines.Dto;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lion.CodeGenerator.BusinessLines;

public interface IBusinessLineAppService : IApplicationService
{

    /// <summary>
    /// 分页查询业务线
    /// </summary>
    /// <param name="input"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PagedResultDto<BusinessLineOutput>> GetPagedListAsync(PagingBusinessLineListInput input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 创建业务线
    /// </summary>
    Task<BusinessLineOutput> CreateBusinessLineAsync(CreateBusinessLineInput input);

    /// <summary>
    /// 修改业务线
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<BusinessLineOutput> UpdateBusinessLineAsync(UpdateBusinessLineInput input);

    /// <summary>
    /// 删除业务线
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task DeleteAsync(IdInput input);

    /// <summary>
    /// 创建业务线下项目
    /// </summary>
    Task<BusinessLineOutput> CreateBusinessProjectAsync(CreateBusinessProjectInput input);

    /// <summary>
    /// 更新业务线项目
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<BusinessLineOutput> UpdateBusinessProjectAsync(UpdateBusinessProjectInput input);

    /// <summary>
    /// 删除业务线项目
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task DeleteBusinessProjectAsync(DeleteBusinessProjectInput input);
}