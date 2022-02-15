using Lion.AbpPro;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Lion.CodeGenerator
{
    [DependsOn(
        typeof(CodeGeneratorApplicationContractsModule),
        typeof(AbpProHttpApiClientModule)
    )]
    public class CodeGeneratorHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(CodeGeneratorApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
