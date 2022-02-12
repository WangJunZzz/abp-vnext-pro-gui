using Lion.AbpPro.Extension.Customs.Dtos;

namespace Lion.CodeGenerator.IdentityServers.IdentityResources.Dtos
{
    public class PagingIdentityResourceListInput : PagingBase
    {
        public string Filter { get; set; }
    }
}