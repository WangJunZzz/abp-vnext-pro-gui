using System;

namespace Lion.CodeGenerator.AggregateModels.Dto;

public class DeleteAggregateEntityInput
{
    /// <summary>
    /// 聚合根ID
    /// </summary>
    public Guid AggregateId { get; set; }
    /// <summary>
    /// 实体id
    /// </summary>
    public Guid AggregateEntityId { get; set; }
}