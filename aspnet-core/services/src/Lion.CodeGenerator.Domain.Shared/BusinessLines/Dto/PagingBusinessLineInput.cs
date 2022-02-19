using Lion.AbpPro.Extension.Customs.Dtos;

namespace Lion.CodeGenerator.BusinessLines.Dto;

public class PagingBusinessLineInput : PagingBase
{
    /// <summary>
    /// 模糊搜索， 描述 和 name
    /// </summary>
    public string Filter { get; set; }
}