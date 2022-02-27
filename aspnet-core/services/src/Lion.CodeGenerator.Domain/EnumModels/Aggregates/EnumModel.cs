using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lion.CodeGenerator.EnumModels.Aggregates;

public class EnumModel : FullAuditedAggregateRoot<Guid>,IMultiTenant
{
    private EnumModel(string code, string description)
    {
        Code = code;
        Description = description;
        EnumProperties = new List<EnumProperty>();
    }

    public EnumModel(Guid id, Guid aggregateModelId, string code, string description, Guid? tenantId) : base(id)
    {
        TenantId = tenantId;
        AggregateModelId = aggregateModelId;
        Code = code;
        Description = description;
        EnumProperties = new List<EnumProperty>();
    }

    
    public Guid? TenantId { get; private set; }
    
    /// <summary>
    /// 聚合根Id
    /// </summary>
    public Guid AggregateModelId { get; private set; }

    /// <summary>
    /// 枚举Code
    /// </summary>
    public string Code { get; private set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; private set; }

    public List<EnumProperty> EnumProperties { get; private set; }

    public void AddEnumProperty(Guid enumModelId, string code, string description, int value)
    {
        if (EnumProperties.Any(e => e.Code == code))
        {
            throw new UserFriendlyException($"枚举{code}已存在");
        }

        if (EnumProperties.Any(e => e.Value == value))
        {
            throw new UserFriendlyException($"枚举值{value}已存在");
        }

        EnumProperties.Add(new EnumProperty(Id, code, description, value));
    }

}