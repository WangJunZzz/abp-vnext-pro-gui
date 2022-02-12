using Lion.AbpPro.Extension.Customs.Dtos;

namespace Lion.CodeGenerator.IdentityServers.ApiScopes.Dtos
{
    public class PagingApiScopeListInput : PagingBase
    {
        public string Filter { get; set; }
    }
}