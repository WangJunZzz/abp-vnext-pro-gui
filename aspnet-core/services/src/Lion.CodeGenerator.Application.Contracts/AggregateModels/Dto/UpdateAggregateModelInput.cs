using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.CodeGenerator.AggregateModels.Dto;

public class UpdateAggregateModelInput
{
    public Guid Id { get;  set; }
    
    /// <summary>
    /// 聚合根类Code
    /// </summary>
    [Required(ErrorMessage = "聚合根Code不能为空")]
    public string Code { get;  set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get;  set; }
}