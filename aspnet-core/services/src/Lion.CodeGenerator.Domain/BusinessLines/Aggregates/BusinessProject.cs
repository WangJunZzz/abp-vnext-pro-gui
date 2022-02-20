using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Lion.CodeGenerator.BusinessLines.Aggregates;

/// <summary>
/// 业务线项目
/// </summary>
public class BusinessProject : CreationAuditedEntity<Guid>
{
    //public Guid BusinessProjectId { get; private set; }

    /// <summary>
    /// 业务线id
    /// </summary>
    public Guid BusinessLineId { get; private set; }

    /// <summary>
    /// 项目名称
    /// </summary>
    [Required]
    [MaxLength(256)]
    public string Name { get; private set; }

    /// <summary>
    /// 命名空间
    /// </summary>
    [Required]
    [MaxLength(256)]
    public string NameSpace { get; private set; }

    /// <summary>
    /// 启用禁用
    /// </summary>
    public bool Enable { get; private set; }

    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(512)]
    public string Description { get; private set; }

    private BusinessProject()
    {

    }
    public BusinessProject(
        //Guid businessProjectId, 
        Guid id,
        Guid businessLineId,
        string name,
        string nameSpace,
        bool enable,
        string description) : base(id)
    {
        //BusinessProjectId = businessProjectId;
        SetProperties(businessLineId,name, nameSpace, enable, description);
    }

    private void SetProperties(Guid businessLineId,string name, string nameSpace, bool enable, string description)
    {
        SetBusinessLineId(businessLineId);
        SetName(name);
        SetNameSpace(nameSpace);
        SetEnable(enable);
        SetDescription(description);
    }

    public void SetBusinessLineId(Guid businessLineId)
    {
        BusinessLineId = businessLineId;
    }

    public void SetName(string name)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name), BusinessProjectMaxLengths.Name);
        Name = name;
    }

    public void SetNameSpace(string nameSpace)
    {
        Check.NotNullOrWhiteSpace(nameSpace, nameof(nameSpace), BusinessProjectMaxLengths.Description);
        NameSpace = nameSpace;
    }

    public void SetEnable(bool enable)
    {
        Enable = enable;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }

    //public override object[] GetKeys()
    //{
    //    return new object[] { BusinessLineId, BusinessProjectId };
    //}
}