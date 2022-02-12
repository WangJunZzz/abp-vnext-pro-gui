using Lion.CodeGenerator.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Lion.CodeGenerator
{
    [DependsOn(
        typeof(CodeGeneratorEntityFrameworkCoreTestModule)
        )]
    public class CodeGeneratorDomainTestModule : AbpModule
    {

    }
}