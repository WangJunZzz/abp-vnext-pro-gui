using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lion.CodeGenerator.AggregateModels.Aggregates;

/// <summary>
/// 聚合根模型
/// </summary>
public class AggregateModel : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    private AggregateModel()
    {
        Properties = new List<PropertyModel>();
        EntityModels = new List<EntityModel>();
    }

    public AggregateModel(Guid id,Guid businessLineId,Guid businessProjectId, string code, string description, Guid? tenantId) : base(id)
    {
        TenantId = tenantId;
        BusinessLineId = businessLineId;
        BusinessProjectId = businessProjectId;
        SetCode(code);
        Description = description;
        Properties = new List<PropertyModel>();
        EntityModels = new List<EntityModel>();
    }

    public Guid? TenantId { get; private set; }

    /// <summary>
    /// 业务线id
    /// </summary>
    public Guid BusinessLineId { get; private set; }
    
    /// <summary>
    /// 项目Id
    /// </summary>
    public Guid BusinessProjectId { get; set; }
    
    /// <summary>
    /// 聚合根类Code
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

    /// <summary>
    /// 聚合根实体，包括实体关系
    /// </summary>
    public List<EntityModel> EntityModels { get; set; }

    private void SetCode(string code)
    {
        Check.NotNullOrWhiteSpace(code, nameof(code));
        Code = code;
    }


    public void UpdateCodeAndDescription(string code, string description)
    {
        SetCode(code);
        Description = description;
    }
    

    public void AddEntity(
        Guid id,
        string code,
        string description,
        RelationType relationType)
    {
        if (EntityModels.Any(e => e.Code == code))
        {
            throw new UserFriendlyException($"{code} 实体已存在");
        }

        EntityModels.Add(new EntityModel(id, Id, code, description, relationType));
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
                Id,
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