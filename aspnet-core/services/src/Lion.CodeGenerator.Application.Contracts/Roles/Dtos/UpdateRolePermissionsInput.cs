using System.ComponentModel.DataAnnotations;
using Volo.Abp.PermissionManagement;

namespace Lion.CodeGenerator.Roles.Dtos
{
    public class UpdateRolePermissionsInput
    {
        [Required]
        public string ProviderName { get; set; }

        [Required]
        public string ProviderKey { get; set; }

        public UpdatePermissionsDto UpdatePermissionsDto { get; set; }
    }
}