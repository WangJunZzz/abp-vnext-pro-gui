using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Lion.CodeGenerator.AggregateModels;

public class EntityModel : Entity<Guid>
{
    public Guid AggregateModelId { get; private set; }

    public string Code { get; private set; }

    public string Name { get; private set; }

    public List<EntityProperty> Properties { get; private set; }
    
    public RelationType RelationType { get; private set; }
}