using Lion.CodeGenerator.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Lion.CodeGenerator.Permissions
{
    public class CodeGeneratorPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CodeGeneratorResource>(name);
        }
    }
}