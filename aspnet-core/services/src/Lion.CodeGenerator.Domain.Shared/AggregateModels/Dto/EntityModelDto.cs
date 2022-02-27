using System;
using System.Collections.Generic;

namespace Lion.CodeGenerator.AggregateModels.Dto;

public class EntityModelDto
{
    public string Id { get; set; }
    
    /// <summary>
    /// 聚合根Id
    /// </summary>
    public Guid AggregateModelId { get;  set; }

    /// <summary>
    /// 属性Code
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
    
    public RelationType RelationType { get;  set; }
}