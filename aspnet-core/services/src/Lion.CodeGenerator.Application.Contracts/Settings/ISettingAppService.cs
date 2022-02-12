using System.Collections.Generic;
using System.Threading.Tasks;
using Lion.CodeGenerator.Settings.Dtos;
using Volo.Abp.Application.Services;

namespace Lion.CodeGenerator.Settings
{
    public interface ISettingAppService : IApplicationService
    {
        /// <summary>
        /// 获取setting信息
        /// </summary>
        /// <returns></returns>
        Task<List<SettingOutput>> GetAsync();
        
        /// <summary>
        /// 更新setting
        /// </summary>
        /// <returns></returns>
        Task UpdateAsync(UpdateSettingInput input);
    }
}