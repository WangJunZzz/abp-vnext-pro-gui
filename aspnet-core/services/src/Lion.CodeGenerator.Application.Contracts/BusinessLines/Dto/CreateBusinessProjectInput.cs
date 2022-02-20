using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.CodeGenerator.BusinessLines.Dto;

public class CreateBusinessProjectInput
{
    /// <summary>
    /// 业务线id
    /// </summary>
    /// 
    [Required]
    public Guid BusinessLineId { get; set; }

    [Required(ErrorMessage = "业务线项目必填")]
    [MaxLength(256)]
    public string Name { get; set; }

    /// <summary>
    /// 命名空间
    /// </summary>
    [Required(ErrorMessage = "命名空间必填")]
    [MaxLength(256)]
    public string NameSpace { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(512)]
    public string Description { get; set; }

    public bool Enable { get; set; }
}