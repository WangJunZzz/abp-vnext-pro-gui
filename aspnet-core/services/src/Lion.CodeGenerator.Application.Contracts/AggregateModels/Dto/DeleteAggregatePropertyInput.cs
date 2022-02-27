using System;

namespace Lion.CodeGenerator.AggregateModels.Dto;

public class DeleteAggregatePropertyInput
{
    /// <summary>
    /// 聚合根ID
    /// </summary>
    public Guid AggregateId { get; set; }
    /// <summary>
    /// 属性id
    /// </summary>
    public Guid AggregatePropertyId { get; set; }
}