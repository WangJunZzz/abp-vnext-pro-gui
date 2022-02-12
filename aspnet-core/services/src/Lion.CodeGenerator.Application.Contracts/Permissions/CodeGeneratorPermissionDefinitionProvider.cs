using Lion.CodeGenerator.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Lion.CodeGenerator.Permissions
{
    public class CodeGeneratorPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var abpIdentityGroup = context.GetGroup(IdentityPermissions.GroupName);
            var userManagement = abpIdentityGroup.GetPermissionOrNull(IdentityPermissions.Users.Default);
            userManagement.AddChild(CodeGeneratorPermissions.SystemManagement.UserEnable, L("Permission:Enable"));

            var auditManagement =
                abpIdentityGroup.AddPermission(CodeGeneratorPermissions.SystemManagement.AuditLog, L("Permission:AuditLogManagement"));
            var esManagement = abpIdentityGroup.AddPermission(CodeGeneratorPermissions.SystemManagement.ES, L("Permission:ESManagement"));
            var settingManagement = abpIdentityGroup.AddPermission(CodeGeneratorPermissions.SystemManagement.Setting, L("Permission:SettingManagement"));

            #region IdentityServer

            // multiTenancySide: MultiTenancySides.Host 只有host租户才有权限
            var identityServerManagementGroup =
                context.AddGroup(CodeGeneratorPermissions.IdentityServer.IdentityServerManagement, L("Permission:IdentityServerManagement"),
                    multiTenancySide: MultiTenancySides.Host);

            var clientManagment = identityServerManagementGroup.AddPermission(CodeGeneratorPermissions.IdentityServer.Client.Default,
                L("Permission:IdentityServerManagement:Client"),multiTenancySide: MultiTenancySides.Host);
            clientManagment.AddChild(CodeGeneratorPermissions.IdentityServer.Client.Create,
                L("Permission:Create"),multiTenancySide: MultiTenancySides.Host);
            clientManagment.AddChild(CodeGeneratorPermissions.IdentityServer.Client.Update,
                L("Permission:Update"),multiTenancySide: MultiTenancySides.Host);
            clientManagment.AddChild(CodeGeneratorPermissions.IdentityServer.Client.Delete,
                L("Permission:Delete"),multiTenancySide: MultiTenancySides.Host);
            clientManagment.AddChild(CodeGeneratorPermissions.IdentityServer.Client.Enable,
                L("Permission:Enable"),multiTenancySide: MultiTenancySides.Host);


            var apiResourceManagment = identityServerManagementGroup.AddPermission(
                CodeGeneratorPermissions.IdentityServer.ApiResource.Default,
                L("Permission:IdentityServerManagement:ApiResource"),multiTenancySide: MultiTenancySides.Host);
            apiResourceManagment.AddChild(CodeGeneratorPermissions.IdentityServer.ApiResource.Create,
                L("Permission:Create"),multiTenancySide: MultiTenancySides.Host);
            apiResourceManagment.AddChild(CodeGeneratorPermissions.IdentityServer.ApiResource.Update,
                L("Permission:Update"),multiTenancySide: MultiTenancySides.Host);
            apiResourceManagment.AddChild(CodeGeneratorPermissions.IdentityServer.ApiResource.Delete,
                L("Permission:Delete"),multiTenancySide: MultiTenancySides.Host);

            var apiScopeManagment = identityServerManagementGroup.AddPermission(CodeGeneratorPermissions.IdentityServer.ApiScope.Default,
                L("Permission:IdentityServerManagement:ApiScope"),multiTenancySide: MultiTenancySides.Host);
            apiScopeManagment.AddChild(CodeGeneratorPermissions.IdentityServer.ApiScope.Create,
                L("Permission:Create"),multiTenancySide: MultiTenancySides.Host);
            apiScopeManagment.AddChild(CodeGeneratorPermissions.IdentityServer.ApiScope.Update,
                L("Permission:Update"),multiTenancySide: MultiTenancySides.Host);
            apiScopeManagment.AddChild(CodeGeneratorPermissions.IdentityServer.ApiScope.Delete,
                L("Permission:Delete"),multiTenancySide: MultiTenancySides.Host);


            var identityResourcesManagment = identityServerManagementGroup.AddPermission(
                CodeGeneratorPermissions.IdentityServer.IdentityResources.Default,
                L("Permission:IdentityServerManagement:IdentityResources"),multiTenancySide: MultiTenancySides.Host);
            identityResourcesManagment.AddChild(CodeGeneratorPermissions.IdentityServer.IdentityResources.Create,
                L("Permission:Create"),multiTenancySide: MultiTenancySides.Host);
            identityResourcesManagment.AddChild(CodeGeneratorPermissions.IdentityServer.IdentityResources.Update,
                L("Permission:Update"),multiTenancySide: MultiTenancySides.Host);
            identityResourcesManagment.AddChild(CodeGeneratorPermissions.IdentityServer.IdentityResources.Delete,
                L("Permission:Delete"),multiTenancySide: MultiTenancySides.Host);

            #endregion
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CodeGeneratorResource>(name);
        }
    }
}