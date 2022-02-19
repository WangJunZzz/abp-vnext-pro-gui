using Lion.AbpPro.Extension.Customs.Dtos;

namespace Lion.CodeGenerator.BusinessLines.Dto
{
    public class PagingBusinessLineListInput : PagingBase
    {
        public string Filter { get; set; }
    }
}