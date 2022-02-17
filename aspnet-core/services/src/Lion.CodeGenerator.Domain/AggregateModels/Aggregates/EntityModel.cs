using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Lion.CodeGenerator.AggregateModels;

/// <summary>
/// 实体模型
/// </summary>
public class EntityModel : Entity<Guid>
{
    private EntityModel()
    {
        Properties = new List<PropertyModel>();
    }
    public EntityModel(
        Guid id,
        Guid aggregateModelId,
        string code,
        string description,
        RelationType relationType) : base(id)
    {
        AggregateModelId = aggregateModelId;
        SetCode(code);
        Description = description;
        Properties = new List<PropertyModel>();
        RelationType = relationType;
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
    /// 属性
    /// </summary>
    public List<PropertyModel> Properties { get; private set; }
    
    public RelationType RelationType { get; private set; }
    
    private void SetCode(string code)
    {
        Check.NotNullOrWhiteSpace(code, nameof(code));
        Code = code;
    }

    public void Update(string code,
        string description,
        RelationType relationType)
    {
        SetCode(code);
        Description = description;
        RelationType = relationType;
    }
    
    public void AddProperty(
        Guid id,
        string code,
        string description,
        bool isRequired,
        string type,
        Guid? enumModelId,
        int stringMaxLength,
        int decimalPrecision,
        int decimalScale)
    {
        if (Properties.Any(e => e.Code == code))
        {
            throw new UserFriendlyException($"{code} 属性已存在");
        }

        Properties.Add(
            new PropertyModel(
                id, 
                AggregateModelId,
                code, 
                description, 
                isRequired, 
                type, 
                enumModelId,
                stringMaxLength,
                decimalPrecision,
                decimalScale));
    }
}