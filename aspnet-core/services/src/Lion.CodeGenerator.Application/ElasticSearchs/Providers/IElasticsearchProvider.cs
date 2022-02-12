using Nest;
using Volo.Abp.DependencyInjection;

namespace Lion.CodeGenerator.ElasticSearchs.Providers
{
    public interface IElasticsearchProvider : ISingletonDependency
    {
        IElasticClient GetElasticClient();
    }
}