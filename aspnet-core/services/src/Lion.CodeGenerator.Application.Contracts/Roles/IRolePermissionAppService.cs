using System.Threading.Tasks;
using Lion.CodeGenerator.Roles.Dtos;
using Volo.Abp.Application.Services;

namespace Lion.CodeGenerator.Roles
{
    public interface IRolePermissionAppService : IApplicationService
    {
        
        Task<PermissionOutput> GetPermissionAsync(GetPermissionInput input);

        Task UpdatePermissionAsync(UpdateRolePermissionsInput input);
    }
}