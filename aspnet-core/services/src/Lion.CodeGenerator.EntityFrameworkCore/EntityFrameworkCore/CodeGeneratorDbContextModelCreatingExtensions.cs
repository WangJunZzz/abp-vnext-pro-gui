using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Lion.CodeGenerator.EntityFrameworkCore
{
    public static class CodeGeneratorDbContextModelCreatingExtensions
    {
        public static void ConfigureCodeGenerator(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(CodeGeneratorConsts.DbTablePrefix + "YourEntities", CodeGeneratorConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}