using System;

namespace Lion.CodeGenerator.AggregateModels.Dto;

public class UpdateAggregatePropertyInput
{
    /// <summary>
    /// 聚合根Id
    /// </summary>
    public Guid AggregateId { get; set; }
    /// <summary>
    /// 属性id
    /// </summary>
    public Guid AggregatePropertyId { get; set; }
    
    /// <summary>
    /// 属性Code
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 是否必填
    /// </summary>
    public bool IsRequired { get; set; }

    /// <summary>
    ///  属性数据类型
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Type== eumn 该字段才有值
    /// </summary>
    public Guid? EnumModelId { get; set; }

    /// <summary>
    /// Type== string  string 类型的最大长度
    /// </summary>
    public int StringMaxLength { get; set; }

    /// <summary>
    /// Type== decimal 的小数位数 (18,3) 中的18
    /// </summary>
    public int DecimalPrecision { get; set; }

    /// <summary>
    /// Type== decimal 的字段长度 (18,3) 中的3
    /// </summary>
    public int DecimalScale { get; set; }
}