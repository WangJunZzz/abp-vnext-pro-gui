using System.Threading.Tasks;

namespace Lion.CodeGenerator.Data
{
    public interface ICodeGeneratorDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
