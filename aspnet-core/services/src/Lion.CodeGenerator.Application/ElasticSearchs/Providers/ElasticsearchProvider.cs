using System;
using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Nest;
using Volo.Abp.DependencyInjection;

namespace Lion.CodeGenerator.ElasticSearchs.Providers
{
    public class ElasticsearchProvider : IElasticsearchProvider, ISingletonDependency
    {
        private readonly IConfiguration _configuration;

        public ElasticsearchProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IElasticClient GetElasticClient()
        {
            var pool = new SingleNodeConnectionPool(new Uri(_configuration.GetValue<string>("ElasticSearch:Url")));
            var connectionSettings =
                new ConnectionSettings(pool);
            connectionSettings.EnableHttpCompression();
            connectionSettings.BasicAuthentication(_configuration.GetValue<string>("ElasticSearch:UserName"),
                _configuration.GetValue<string>("ElasticSearch:Password"));
            return new ElasticClient(connectionSettings);
        }
    }
}