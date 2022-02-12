using Lion.AbpPro.Extension.Customs.Dtos;

namespace Lion.CodeGenerator.IdentityServers.ApiResources.Dtos
{
        public class PagingApiRseourceListInput : PagingBase
        {
            public string Filter { get; set; }
        }
}