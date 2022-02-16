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
                b.ApplyObjectExtensionMappings();
            });
            
            builder.Entity<BusinessProject>(b =>
            {
                b.ToTable(CodeGeneratorDbProperties.DbTablePrefix + nameof(BusinessProject), CodeGeneratorDbProperties.DbSchema);
                b.ConfigureByConvention();
                b.HasKey(x => new { x.BusinessLineId, x.BusinessProjectId });
                b.ApplyObjectExtensionMappings();
            });
        }
    }
}