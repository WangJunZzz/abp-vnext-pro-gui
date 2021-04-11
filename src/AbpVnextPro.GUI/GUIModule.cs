using AbpVnextPro.GUI.ApplicationService;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpVnextPro.GUI
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpVnextProGUIApplicationService))]
    public class GUIModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSingleton<MainWindow>();
        }
    }
}
