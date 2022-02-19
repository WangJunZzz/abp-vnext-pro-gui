using Hangfire;
using Lion.AbpPro.Jobs;
using Lion.CodeGenerator.Extensions.Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace Lion.CodeGenerator.Extensions
{
    public static class RecurringJobsExtensions
    {
        public static void CreateRecurringJob(this ApplicationInitializationContext context)
        {
            using var scope = context.ServiceProvider.CreateScope();
            var testJob =
                scope.ServiceProvider.GetService<TestJob>();
            RecurringJob.AddOrUpdate("测试Job", () => testJob.ExecuteAsync(), CronType.Minute(1));
        }
    }
}