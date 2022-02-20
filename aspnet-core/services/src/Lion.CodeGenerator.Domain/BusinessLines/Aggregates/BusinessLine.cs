﻿using System;
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

    private void SetTenantId(Guid? tenantId)
    {
        TenantId = tenantId;
    }

    private void SetName(string name)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name), BusinessLineMaxLengths.Name);
        Name = name;
    }

    private void SetEnable(bool enable)
    {
        Enable = enable;
    }

    private void SetDescription(string description)
    {
        Check.NotNullOrWhiteSpace(description, nameof(description), BusinessLineMaxLengths.Description);
        Description = description;
    }

    public BusinessLine ChangeName(string name)
    {
        SetName(name);
        return this;
    }

    /// <summary>
    /// 更新业务线
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="name"></param>
    /// <param name="enable"></param>
    /// <param name="description"></param>
    public void UpdateBuisinessLine(
        Guid? tenantId,
        string name,
        bool enable,
        string description
        )
    {
        SetTenantId(tenantId);
        SetName(name);
        SetEnable(enable);
        SetDescription(description);
    }

    /// <summary>
    /// 新增业务线项目
    /// </summary>
    /// <param name="id"></param>
    /// <param name="businessLineId"></param>
    /// <param name="name"></param>
    /// <param name="nameSpace"></param>
    /// <param name="enable"></param>
    /// <param name="description"></param>
    /// <exception cref="UserFriendlyException"></exception>
    public void AddBusinessProject(
        Guid id,
        Guid businessLineId,
        string name,
        string nameSpace,
        bool enable,
        string description)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));
        Check.NotNullOrWhiteSpace(nameSpace, nameof(nameSpace));

        if (BusinessProjects.Any(e => e.Name == name))
        {
            throw new UserFriendlyException($"业务线项目名称{name}已存");
        }

        BusinessProjects.Add(new BusinessProject(id, businessLineId, name, nameSpace, enable, description));
    }

    /// <summary>
    /// 更新业务线项目
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="nameSpace"></param>
    /// <param name="enable"></param>
    /// <param name="description"></param>
    public BusinessLine UpdateBusinessProject(
        Guid id,
        string name,
        string nameSpace,
        bool enable,
        string description)
    {
        var businessProject = BusinessProjects.Find(e => e.Id == id);

        if (businessProject == null)
        {
            throw new UserFriendlyException($"业务线项目id：{id}不存在");
        }

        //Check.NotNull(businessProject, nameof(businessProject));

        businessProject.SetName(name);
        businessProject.SetEnable(enable);
        businessProject.SetNameSpace(nameSpace);
        businessProject.SetDescription(description);

        return this;
    }

    /// <summary>
    /// 删除业务线项目
    /// </summary>
    /// <param name="businessLineId"></param>
    /// <param name="businessProjectId"></param>
    /// <returns></returns>
    /// <exception cref="UserFriendlyException"></exception>
    public BusinessLine RemoveBusinessProject(Guid businessLineId, Guid businessProjectId)
    {
        var businessProject = BusinessProjects.Find(b => b.BusinessLineId == businessLineId && b.Id == businessProjectId);
        if (businessProject == null)
        {
            throw new UserFriendlyException($"业务线项目id：{businessProjectId}不存在");
        }

        BusinessProjects.Remove(businessProject);

        return this;
    }
}