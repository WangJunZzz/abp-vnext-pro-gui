using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lion.CodeGenerator.AggregateModels;

/// <summary>
/// 聚合根模型
/// </summary>
public class AggregateModel : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; private set; }

    /// <summary>
    /// 聚合根类Code
    /// </summary>
    public string Code { get; private set; }

    /// <summary>
    /// 聚合根名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 聚合根属性
    /// </summary>
    public List<EntityProperty> Properties { get; private set; }

    /// <summary>
    /// 聚合根实体，包括实体关系
    /// </summary>
    public List<EntityModel> EntityModels { get; set; }
}