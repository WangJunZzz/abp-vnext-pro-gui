using Volo.Abp.Modularity;

namespace Lion.CodeGenerator
{
    [DependsOn(
        typeof(CodeGeneratorApplicationModule),
        typeof(CodeGeneratorDomainTestModule)
        )]
    public class CodeGeneratorApplicationTestModule : AbpModule
    {

    }
}