using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lion.CodeGenerator.AggregateModels;
using Lion.CodeGenerator.AggregateModels.Aggregates;
using Lion.CodeGenerator.BusinessLines.Aggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Lion.CodeGenerator.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public interface ICodeGeneratorDbContext : IEfCoreDbContext
    {
        DbSet<BusinessLine> BusinessLines { get; }
        public DbSet<AggregateModel> AggregateModels { get; }
    }
}
