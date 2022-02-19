using System.Threading.Tasks;
using Lion.AbpPro.Extension.Customs.Dtos;
using Lion.CodeGenerator.BusinessLines.Dto;
using Volo.Abp.Application.Services;

namespace Lion.CodeGenerator.BusinessLines;

public interface IBusinessLineAppService : IApplicationService
{
    /// <summary>
    /// 分页查询业务线
    /// </summary>
    /// <returns></returns>
    Task<CustomePagedResultDto<PagingBusinessLineOutput>>
        PagingAsync(PagingBusinessLineInput input);

    /// <summary>
    /// 创建业务线
    /// </summary>
    Task CreateBusinessLineAsync(CreateBusinessLineInput input);

    /// <summary>
    /// 创建业务线下项目
    /// </summary>
    Task CreateBusinessProjectAsync(CreateBusinessProjectInput input);
}