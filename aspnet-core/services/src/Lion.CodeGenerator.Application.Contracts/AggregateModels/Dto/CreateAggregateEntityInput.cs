using System;

namespace Lion.CodeGenerator.AggregateModels.Dto;

public class CreateAggregateEntityInput
{
    /// <summary>
    /// 聚合根Id
    /// </summary>
    public Guid AggregateId { get;  set; }

    /// <summary>
    /// 属性Code
    /// </summary>
    public string Code { get;  set; }
    
    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get;  set; }
    
    /// <summary>
    /// 关系
    /// </summary>
    public RelationType RelationType { get; set; }
}