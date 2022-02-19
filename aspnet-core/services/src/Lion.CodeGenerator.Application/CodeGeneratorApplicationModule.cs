using Lion.AbpPro;
using Lion.CodeGenerator.FreeSqlRepository;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Lion.CodeGenerator
{
    [DependsOn(
        typeof(CodeGeneratorDomainModule),
        typeof(CodeGeneratorApplicationContractsModule),
        typeof(AbpProApplicationModule),
        typeof(CodeGeneratorFreeSqlModule)
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
