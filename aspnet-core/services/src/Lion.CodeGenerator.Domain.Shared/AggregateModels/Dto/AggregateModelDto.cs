using System;
using System.Collections.Generic;

namespace Lion.CodeGenerator.AggregateModels.Dto;

public class AggregateModelDto
{
    public string Id { get; set; }
    
    public Guid? TenantId { get;  set; }

    /// <summary>
    /// 业务线id
    /// </summary>
    public Guid BusinessLineId { get;  set; }
    
    /// <summary>
    /// 项目Id
    /// </summary>
    public Guid BusinessProjectId { get; set; }
    
    /// <summary>
    /// 聚合根类Code
    /// </summary>
    public string Code { get;  set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get;  set; }

    /// <summary>
    /// 属性
    /// </summary>
    public List<PropertyModelDto> Properties { get;  set; }

    /// <summary>
    /// 聚合根实体，包括实体关系
    /// </summary>
    public List<EntityModelDto> EntityModels { get; set; }
}