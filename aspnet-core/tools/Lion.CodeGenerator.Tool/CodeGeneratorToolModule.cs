using Lion.CodeGenerator.Tool.Views;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Lion.CodeGenerator.Tool
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(CodeGeneratorHttpApiClientModule)
        )]
    public class CodeGeneratorToolModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            var url = configuration["RemoteServices:Default:BaseUrl"];

            Configure<AbpRemoteServiceOptions>(options =>
            {
                options.RemoteServices.Default = new RemoteServiceConfiguration(url);
            });

            context.Services.AddSingleton<LoginWin>();
        }
    }
}