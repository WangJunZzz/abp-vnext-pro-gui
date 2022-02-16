using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lion.CodeGenerator.BusinessLines.Aggregates;

/// <summary>
/// 业务线
/// </summary>
public class BusinessLine : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    /// <summary>
    /// 租户
    /// </summary>
    public Guid? TenantId { get; private set; }

    /// <summary>
    /// 业务线名称
    /// </summary>
    [Required]
    [MaxLength(256)]
    public string Name { get; private set; }

    /// <summary>
    /// 启用禁用
    /// </summary>
    public bool Enable { get; private set; }
    
    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(512)]
    public string Description { get; private set; }

    public List<BusinessProject> BusinessProjects { get; private set; }
}