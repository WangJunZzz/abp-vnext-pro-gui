using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Lion.CodeGenerator.Data;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace Lion.CodeGenerator.EntityFrameworkCore
{
    public class EntityFrameworkCoreCodeGeneratorDbSchemaMigrator
        : ICodeGeneratorDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreCodeGeneratorDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the CodeGeneratorMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<CodeGeneratorDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}