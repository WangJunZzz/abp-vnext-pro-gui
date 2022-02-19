using Lion.CodeGenerator.AggregateModels;
using Lion.CodeGenerator.AggregateModels.Aggregates;
using Lion.CodeGenerator.BusinessLines.Aggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Lion.CodeGenerator.EntityFrameworkCore
{
    public static class CodeGeneratorDbContextModelCreatingExtensions
    {
        public static void ConfigureCodeGenerator(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<BusinessLine>(b =>
            {
                b.ToTable(CodeGeneratorDbProperties.DbTablePrefix + nameof(BusinessLine), CodeGeneratorDbProperties.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => new { x.TenantId, x.Id });
            });

            builder.Entity<BusinessProject>(b =>
            {
                b.ToTable(CodeGeneratorDbProperties.DbTablePrefix + nameof(BusinessProject), CodeGeneratorDbProperties.DbSchema);
                b.ConfigureByConvention();
                b.HasKey(x => new { x.BusinessLineId, x.BusinessProjectId });
            });

            builder.Entity<BusinessProject>(b =>
            {
                b.ToTable(CodeGeneratorDbProperties.DbTablePrefix + nameof(BusinessProject), CodeGeneratorDbProperties.DbSchema);
                b.ConfigureByConvention();
                b.HasKey(x => new { x.BusinessLineId, x.BusinessProjectId });
            });

            builder.Entity<AggregateModel>(b =>
            {
                b.ToTable(CodeGeneratorDbProperties.DbTablePrefix + nameof(AggregateModel), CodeGeneratorDbProperties.DbSchema);
                b.ConfigureByConvention();
                b.HasKey(e => e.Code);
                b.HasKey(x => new { x.TenantId, x.BusinessLineId, x.BusinessProjectId, x.Code });
            });
            
            builder.Entity<EntityModel>(b =>
            {
                b.ToTable(CodeGeneratorDbProperties.DbTablePrefix + nameof(EntityModel), CodeGeneratorDbProperties.DbSchema);
                b.ConfigureByConvention();
                b.HasKey(e => e.Code);
                b.HasKey(x => new { x.AggregateModelId, x.Code });
            });
            
            builder.Entity<PropertyModel>(b =>
            {
                b.ToTable(CodeGeneratorDbProperties.DbTablePrefix + nameof(PropertyModel), CodeGeneratorDbProperties.DbSchema);
                b.ConfigureByConvention();
                b.HasKey(x => new { x.AggregateModelId, x.Code });
            });
        }
    }
}