using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Lion.CodeGenerator.EnumModels;

public class EnumProperty : Entity<Guid>
{
    private EnumProperty()
    {
    }

    public EnumProperty(Guid enumModelId, string code, string description, int value)
    {
        Check.NotNullOrWhiteSpace(code, nameof(code));
        Check.NotNullOrWhiteSpace(description, nameof(description));
        EnumModelId = enumModelId;
        Code = code;
        Description = description;
        Value = value;
    }
    

    public Guid EnumModelId { get; private set; }

    public string Code { get; private set; }

    public string Description { get; private set; }

    public int Value { get; private set; }
}