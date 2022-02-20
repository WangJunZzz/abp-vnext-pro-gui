using System;

namespace Lion.CodeGenerator.EnumModels.Dto;

public class EnumModelDto
{
    /// <summary>
    /// 聚合根Id
    /// </summary>
    public Guid AggregateModelId { get;  set; }

    /// <summary>
    /// 枚举Code
    /// </summary>
    public string Code { get;  set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get;  set; }


}