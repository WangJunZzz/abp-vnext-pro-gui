using Lion.AbpPro;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Lion.CodeGenerator.MultiTenancy;
using Volo.Abp.Emailing;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.AutoMapper;

namespace Lion.CodeGenerator
{
    [DependsOn(
        typeof(CodeGeneratorDomainSharedModule),
        typeof(AbpProDomainModule)
    )]
    public class CodeGeneratorDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MultiTenancyConsts.IsEnabled;
            });

            context.Services.AddAutoMapperObjectMapper<CodeGeneratorDomainModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<CodeGeneratorDomainModule>();
            });

#if DEBUG
            context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
        }
    }
}
