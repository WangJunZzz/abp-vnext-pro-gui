using System;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Lion.CodeGenerator.AggregateModels;

/// <summary>
/// 属性模型
/// </summary>
public class PropertyModel : Entity<Guid>
{
    private PropertyModel()
    {
    }

    public PropertyModel(
        Guid id,
        Guid aggregateModelId,
        string code,
        string description,
        bool isRequired,
        string type,
        Guid? enumModelId,
        int stringMaxLength,
        int decimalPrecision,
        int decimalScale) : base(id)
    {
        AggregateModelId = aggregateModelId;
        SetCode(code);
        Description = description;
        IsRequired = isRequired;
        SetType(type);
        SetEnumModelId(enumModelId);
        SetStringMaxLength(stringMaxLength);
        SetDecimalPrecision(decimalPrecision);
        SetDecimalScale(decimalScale);
        DecimalScale = decimalScale;
    }

    /// <summary>
    /// 聚合根Id
    /// </summary>
    public Guid AggregateModelId { get; private set; }

    /// <summary>
    /// 属性Code
    /// </summary>
    public string Code { get; private set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// 是否必填
    /// </summary>
    public bool IsRequired { get; private set; }

    /// <summary>
    ///  属性数据类型
    /// </summary>
    public string Type { get; private set; }

    /// <summary>
    /// Type== eumn 该字段才有值
    /// </summary>
    public Guid? EnumModelId { get; private set; }

    /// <summary>
    /// Type== string  string 类型的最大长度
    /// </summary>
    public int StringMaxLength { get; private set; }

    /// <summary>
    /// Type== decimal 的小数位数 (18,3) 中的18
    /// </summary>
    public int DecimalPrecision { get; private set; }

    /// <summary>
    /// Type== decimal 的字段长度 (18,3) 中的3
    /// </summary>
    public int DecimalScale { get; private set; }


    private void SetType(string type)
    {
        Check.NotNullOrWhiteSpace(type, nameof(type));

        if (DataTypeConsts.ToList().Any(e => e != type))
        {
            throw new UserFriendlyException($"{type} 未知的数据类型");
        }
    }

    private void SetCode(string code)
    {
        Check.NotNullOrWhiteSpace(code, nameof(code));
        Code = code;
    }

    private void SetName(string name)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));
        Code = name;
    }

    private void SetEnumModelId(Guid? enumModelId)
    {
        if (enumModelId.HasValue && Type != DataTypeConsts.CodeEumn)
        {
            throw new UserFriendlyException($"只有枚举才能赋值");
        }
        EnumModelId = enumModelId;
    }
    
    private void SetStringMaxLength(int maxLength)
    {
        if (maxLength <= 0)
        {
            throw new UserFriendlyException($"最大长度必须大于等于零");
        }

        StringMaxLength = maxLength;
    }
    
    private void SetDecimalPrecision(int decimalPrecision)
    {
        if (decimalPrecision < 0)
        {
            throw new UserFriendlyException($"{DataTypeConsts.CodeDecimal}精度不能为复数");
        }

        DecimalPrecision = decimalPrecision;
    }
    
    private void SetDecimalScale(int decimalScale)
    {
        if (decimalScale < 0)
        {
            throw new UserFriendlyException($"{DataTypeConsts.CodeDecimal}精度不能为复数");
        }

        DecimalScale = decimalScale;
    }

    public void Update(
        string code,
        string description,
        bool isRequired,
        string type,
        Guid? enumModelId,
        int stringMaxLength,
        int decimalPrecision,
        int decimalScale)
    {
        SetCode(code);
        Description = description;
        IsRequired = isRequired;
        SetType(type);
        SetEnumModelId(enumModelId);
        SetStringMaxLength(stringMaxLength);
        SetDecimalPrecision(decimalPrecision);
        SetDecimalScale(decimalScale);
        DecimalScale = decimalScale;
    }
}