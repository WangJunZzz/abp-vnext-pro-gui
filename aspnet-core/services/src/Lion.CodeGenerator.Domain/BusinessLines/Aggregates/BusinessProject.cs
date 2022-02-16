using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace Lion.CodeGenerator.BusinessLines.Aggregates;

/// <summary>
/// 业务线项目
/// </summary>
public class BusinessProject : CreationAuditedEntity
{
    private BusinessProject()
    {
        
    }
    public BusinessProject(Guid businessProjectId, Guid businessLineId, string name, string nameSpace, bool enable, string description)
    {
        BusinessProjectId = businessProjectId;
        BusinessLineId = businessLineId;
        Name = name;
        NameSpace = nameSpace;
        Enable = enable;
        Description = description;
    }

    public Guid BusinessProjectId { get; private set; }

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


    
    public override object[] GetKeys()
    {
        return new object[] { BusinessLineId, BusinessProjectId };
    }
    
    
    
}