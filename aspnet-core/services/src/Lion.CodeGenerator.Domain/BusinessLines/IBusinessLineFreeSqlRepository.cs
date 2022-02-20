using Lion.AbpPro.Extension.Customs.Dtos;
using Lion.CodeGenerator.BusinessLines.Dtos;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Lion.CodeGenerator.BusinessLines;

public interface IBusinessLineFreeSqlRepository:ITransientDependency
{
    /// <summary>
    /// 分页获取业务线
    /// </summary>
    /// <returns></returns>
    Task<CustomePagedResultDto<BusinessLineDto>> PagingAsync(string filter, int pageSize, int pageIndex);
}