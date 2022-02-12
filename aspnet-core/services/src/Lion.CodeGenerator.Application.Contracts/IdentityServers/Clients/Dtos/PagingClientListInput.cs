using Lion.AbpPro.Extension.Customs.Dtos;

namespace Lion.CodeGenerator.IdentityServers.Clients.Dtos
{
    public class PagingClientListInput:PagingBase
    {
        public string Filter { get; set; }
    }
}