using System.Collections.Generic;
using System.Threading.Tasks;
using Lion.AbpPro.Extension.Customs.Dtos;
using Lion.CodeGenerator.IdentityServers.ApiResources.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lion.CodeGenerator.IdentityServers.ApiResources
{
    public interface IApiResourceAppService : IApplicationService
    {
        Task<PagedResultDto<ApiResourceOutput>> GetListAsync(PagingApiRseourceListInput input);

        /// <summary>
        /// 获取所有api resource
        /// </summary>
        /// <returns></returns>
        Task<List<ApiResourceOutput>> GetApiResources();

        /// <summary>
        /// 新增 ApiResource
        /// </summary>
        /// <returns></returns>
        Task CreateAsync(CreateApiResourceInput input);

        /// <summary>
        /// 删除 ApiResource
        /// </summary>
        /// <returns></returns>
        Task DeleteAsync(IdInput input);

        /// <summary>
        /// 更新 ApiResource
        /// </summary>
        /// <returns></returns>
        Task UpdateAsync(UpdateApiResourceInput input);
    }
}