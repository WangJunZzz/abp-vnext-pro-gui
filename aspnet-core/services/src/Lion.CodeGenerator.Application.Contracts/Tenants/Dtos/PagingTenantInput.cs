using Lion.AbpPro.Extension.Customs.Dtos;

namespace Lion.CodeGenerator.Tenants.Dtos
{
    public class PagingTenantInput : PagingBase
    {
        public string Filter { get; set; }
    }
}