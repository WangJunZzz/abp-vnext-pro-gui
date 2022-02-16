using System.Threading.Tasks;
using Lion.CodeGenerator.BusinessLines.Dto;
using Volo.Abp.Application.Services;

namespace Lion.CodeGenerator.BusinessLines;

public interface IBusinessLineAppService:IApplicationService
{
    /// <summary>
    /// 创建业务线
    /// </summary>
    Task CreateBusinessLineAsync(CreateBusinessLineInput input);

    /// <summary>
    /// 创建业务线下项目
    /// </summary>
    Task CreateBusinessProjectAsync(CreateBusinessProjectInput input);
}