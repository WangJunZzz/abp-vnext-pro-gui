using System;
using Volo.Abp.Domain.Entities;

namespace Lion.CodeGenerator.AggregateModels;

public class AggregateProperty : Entity<Guid>
{

    public Guid AggregateModelId { get; private set; }
    
    /// <summary>
    /// 聚合根属性Code
    /// </summary>
    public string Code { get; private set; }

    /// <summary>
    /// 聚合根属性名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 是否必填
    /// </summary>
    public bool IsRequired { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public bool IsEnum { get; private set; }

    /// <summary>
    /// IsEnum = false 时 DataTypeId 为 BasicDataType.Id
    /// IsEnum = true 时 DataTypeId 为 DesignEnumerate.Id
    /// </summary>
    public Guid DataTypeId { get; private set; }

    public int StringMaxLength { get; private set; }

    public int StringMinLength { get; private set; }

    /// <summary>
    /// 当类型为decimal时的小数位数 (18,4) 中的18
    /// </summary>
    public int DecimalPrecision { get; private set; }

    /// <summary>
    /// 当类型为decimal时的字段长度 (18,4) 中的4
    /// </summary>
    public int DecimalScale { get; private set; }
}