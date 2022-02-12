using Lion.CodeGenerator.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Lion.CodeGenerator.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(CodeGeneratorEntityFrameworkCoreModule),
        typeof(CodeGeneratorApplicationContractsModule)
        )]
    public class CodeGeneratorDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
