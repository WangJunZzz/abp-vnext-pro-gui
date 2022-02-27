using System;

namespace Lion.CodeGenerator.AggregateModels.Dto;

public class DeleteAggregateEntityPropertyInput
{
    /// <summary>
    /// 聚合根Id
    /// </summary>
    public Guid AggregateId { get;  set; }
    /// <summary>
    /// 实体id
    /// </summary>
    public Guid AggregateEntityId { get; set; }

    /// <summary>
    /// 实体属性Id
    /// </summary>
    public Guid AggregateEntityPropertyId { get;  set; }
}