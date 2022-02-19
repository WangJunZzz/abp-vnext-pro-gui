using System;

namespace Lion.CodeGenerator.BusinessLines.Dto;

public class PagingBusinessLineOutput
{
    public Guid Id { get; set; }

    /// <summary>
    /// 业务线名称
    /// </summary>

    public string Name { get; set; }

    /// <summary>
    /// 启用禁用
    /// </summary>
    public bool Disabled { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreationTime { get; set; }
}