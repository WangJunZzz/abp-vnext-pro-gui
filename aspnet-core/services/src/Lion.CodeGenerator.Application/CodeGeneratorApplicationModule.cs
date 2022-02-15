using Lion.AbpPro;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Lion.CodeGenerator
{
    [DependsOn(
        typeof(CodeGeneratorDomainModule),
        typeof(CodeGeneratorApplicationContractsModule),
        typeof(AbpProApplicationModule)
        )]
    public class CodeGeneratorApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<CodeGeneratorApplicationModule>();
            });
            
          
        }
    }
}
