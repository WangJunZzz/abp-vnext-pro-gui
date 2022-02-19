using Lion.AbpPro.Extension.Customs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Volo.Abp;
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

    private BusinessLine()
    {
        BusinessProjects = new List<BusinessProject>();
    }

    public BusinessLine(Guid id, string name, bool enable, string description, Guid? tenantId) : base(id)
    {
        SetProperties(tenantId, name, enable, description);
        BusinessProjects = new List<BusinessProject>();
    }

    private void SetProperties(Guid? tenantId, string name, bool enable, string description)
    {
        SetTenantId(tenantId);
        SetName(name);
        SetEnable(enable);
        SetDescription(description);
    }

    public void SetTenantId(Guid? tenantId)
    {
        TenantId = tenantId;
    }

    public void SetName(string name)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name), BusinessLineMaxLengths.Name);
        Name = name;
    }

    public void SetEnable(bool enable)
    {
        Enable = enable;
    }

    public void SetDescription(string description)
    {
        Check.NotNullOrWhiteSpace(description, nameof(description), BusinessLineMaxLengths.Description);
        Description = description;
    }

    public void AddBusinessProject(Guid businessProjectId, Guid businessLineId, string name, string nameSpace, bool enable, string description)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));
        Check.NotNullOrWhiteSpace(nameSpace, nameof(nameSpace));
        if (BusinessProjects.Any(e => e.Name == name)) throw new UserFriendlyException("当前业务线下已存在该项目");
        BusinessProjects.Add(new BusinessProject(businessProjectId, businessLineId, name, nameSpace, enable, description));
    }
}