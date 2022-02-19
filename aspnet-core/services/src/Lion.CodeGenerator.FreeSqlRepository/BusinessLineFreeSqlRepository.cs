using System;
using System.Threading.Tasks;
using Lion.AbpPro.Extension.Customs.Dtos;
using Lion.AbpPro.Extension.System;
using Lion.CodeGenerator.BusinessLines;
using Lion.CodeGenerator.BusinessLines.Dto;

namespace Lion.CodeGenerator.FreeSqlRepository;

public class BusinessLineFreeSqlRepository : FreeSqlBasicRepository, IBusinessLineFreeSqlRepository
{
    public async Task<CustomePagedResultDto<PagingBusinessLineOutput>> PagingAsync(
        PagingBusinessLineInput input)
    {
        var sql = BuildSql(input);
        var result = await FreeSql.Select<PagingBusinessLineOutput>()
            .WithSql(sql, input)
            .Count(out var total)
            .Page(input.PageIndex, input.PageSize)
            .ToListAsync();

        return new CustomePagedResultDto<PagingBusinessLineOutput>(total, result);
    }

    private string BuildSql(PagingBusinessLineInput input)
    {
        var sql = "select p.id, " +
                  " p.name, " +
                  " p.disabled, " +
                  " p.description, " +
                  " p.creationtime " +
                  " from Gen_BusinessLine p " +
                  " where p.IsDeleted=0 ";
        if (input.Filter.IsNotNullOrWhiteSpace())
        {
            input.Filter = input.Filter.ToSqlContains();
            sql += " and  p.name like ?Filter or p.description like ?Filter";
        }

        sql += " order by CreationTime desc ";
        return sql;
    }
}