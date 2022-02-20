using System.Threading.Tasks;
using Lion.AbpPro.Extension.Customs.Dtos;
using Lion.CodeGenerator.BusinessLines.Dto;
using Volo.Abp.DependencyInjection;

namespace Lion.CodeGenerator.BusinessLines;

public interface IBusinessLineFreeSqlRepository:ITransientDependency
{
    /// <summary>
    /// 分页获取业务线
    /// </summary>
    /// <returns></returns>
    Task<CustomePagedResultDto<PagingBusinessLineOutput>> PagingAsync(PagingBusinessLineInput input);
}