using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lion.CodeGenerator.AggregateModels;

public class AggregateModel : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public string Code { get; private set; }

    public string Name { get; private set; }

    public Guid? TenantId { get; private set; }

    public List<EntityModel> EntityModels { get; set; }
}