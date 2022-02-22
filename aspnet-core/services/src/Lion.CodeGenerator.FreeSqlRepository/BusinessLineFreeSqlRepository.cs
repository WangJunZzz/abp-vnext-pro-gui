using Lion.AbpPro.Extension.Customs.Dtos;
using Lion.AbpPro.Extension.System;
using Lion.CodeGenerator.BusinessLines;
using Lion.CodeGenerator.BusinessLines.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lion.CodeGenerator.FreeSqlRepository;

public class BusinessLineFreeSqlRepository : FreeSqlBasicRepository, IBusinessLineFreeSqlRepository
{
    public async Task<CustomePagedResultDto<BusinessLineDto>> PagingAsync(
        string filter, int pageSize, int pageIndex, CancellationToken cancellationToken = default)
    {
        var sql = BuildSql(filter);
        var result = await FreeSql.Select<BusinessLineDto>()
            .WithSql(sql, filter)
            .Count(out var total)
            .Page(pageIndex, pageSize)
            .ToListAsync(cancellationToken: cancellationToken);

        return new CustomePagedResultDto<BusinessLineDto>(total, result);
    }

    private string BuildSql(string filter)
    {
        //var sql = "select p.id, " +
        //          " p.tenantId, " +
        //          " p.name, " +
        //          " p.enable, " +
        //          " p.description, " +
        //          " p.creationtime " +
        //          " from Gen_BusinessLine p " +
        //          " where p.IsDeleted=0 ";

        var sql = @$"select p.id,  p.tenantId,  p.name,  p.enable,  p.description,  p.creationtime 
                     from Gen_BusinessLine p left join gen_businessproject b on p.id = b.BusinessLineId  where p.IsDeleted = 0  ";
        if (filter.IsNotNullOrWhiteSpace())
        {
            filter = filter.ToSqlContains();
            sql += " and  p.name like ?Filter or p.description like ?Filter";
        }

        sql += " order by CreationTime desc ";
        return sql;
    }
}