using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Lion.CodeGenerator.Data
{
    /* This is used if database provider does't define
     * ICodeGeneratorDbSchemaMigrator implementation.
     */
    public class NullCodeGeneratorDbSchemaMigrator : ICodeGeneratorDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}