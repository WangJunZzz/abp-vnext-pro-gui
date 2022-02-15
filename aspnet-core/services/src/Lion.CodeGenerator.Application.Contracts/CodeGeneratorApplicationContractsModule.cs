using Lion.AbpPro;
using Volo.Abp.Modularity;

namespace Lion.CodeGenerator
{
    [DependsOn(
        typeof(CodeGeneratorDomainSharedModule),
        typeof(AbpProApplicationContractsModule)
    )]
    public class CodeGeneratorApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            CodeGeneratorDtoExtensions.Configure();
        }
    }
}
