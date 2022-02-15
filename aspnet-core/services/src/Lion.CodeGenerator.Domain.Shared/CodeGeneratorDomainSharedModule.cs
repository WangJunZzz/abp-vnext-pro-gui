using Lion.AbpPro;
using Lion.AbpPro.DataDictionaryManagement;
using Lion.AbpPro.FileManagement;
using Lion.AbpPro.Localization;
using Lion.AbpPro.NotificationManagement;
using Lion.CodeGenerator.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Localization;
using Volo.Abp.IdentityServer;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Localization.Resources.AbpLocalization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Timing.Localization.Resources.AbpTiming;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Lion.CodeGenerator
{
    [DependsOn(
        typeof(AbpProDomainSharedModule)
    )]
    public class CodeGeneratorDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            CodeGeneratorGlobalFeatureConfigurator.Configure();
            CodeGeneratorModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CodeGeneratorDomainSharedModule>("Lion.CodeGenerator");
            });
          
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<CodeGeneratorResource>("zh-Hans")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddBaseTypes(typeof(AbpLocalizationResource))
                    .AddBaseTypes(typeof(IdentityResource))
                    .AddBaseTypes(typeof(AbpTimingResource))
                    .AddBaseTypes(typeof(AbpProResource))
                    .AddVirtualJson("/Localization/CodeGenerator");

                options.DefaultResourceType = typeof(CodeGeneratorResource);
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("CodeGenerator", typeof(CodeGeneratorResource));
            });

           
        }

       
    }
}