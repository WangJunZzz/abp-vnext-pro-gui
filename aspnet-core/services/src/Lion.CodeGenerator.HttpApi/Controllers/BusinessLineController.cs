using Lion.AbpPro.Extension.Customs.Dtos;
using Lion.CodeGenerator.BusinessLines;
using Lion.CodeGenerator.BusinessLines.Dto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Lion.CodeGenerator.Controllers;

[Route("api/code-generator/business-lines")]
public class BusinessLineController : CodeGeneratorController, IBusinessLineAppService
{
    private readonly IBusinessLineAppService _businessLineAppService;

    public BusinessLineController(IBusinessLineAppService businessLineAppService)
    {
        _businessLineAppService = businessLineAppService;
    }

    [HttpPost("page")]
    [SwaggerOperation(summary: "分页获取业务线信息", Tags = new[] { "BusinessLines" })]
    public Task<PagedResultDto<BusinessLineOutput>> GetPagedListAsync(PagingBusinessLineListInput input, CancellationToken cancellationToken = default)
    {
        return _businessLineAppService.GetPagedListAsync(input);
    }

    [HttpPost("create")]
    [SwaggerOperation(summary: "创建业务线", Tags = new[] { "BusinessLines" })]
    public Task<BusinessLineOutput> CreateBusinessLineAsync(CreateBusinessLineInput input)
    {
        return _businessLineAppService.CreateBusinessLineAsync(input);
    }

    [HttpPost("update")]
    [SwaggerOperation(summary: "编辑业务线", Tags = new[] { "BusinessLines" })]
    public Task<BusinessLineOutput> UpdateBusinessLineAsync(UpdateBusinessLineInput input)
    {
        return _businessLineAppService.UpdateBusinessLineAsync(input);
    }

    [HttpPost("delete")]
    [SwaggerOperation(summary: "删除业务线", Tags = new[] { "BusinessLines" })]
    public Task DeleteAsync(IdInput input)
    {
        return _businessLineAppService.DeleteAsync(input);
    }

    [HttpPost("create-business-project")]
    [SwaggerOperation(summary: "创建业务线项目", Tags = new[] { "BusinessLines" })]
    public Task<BusinessLineOutput> CreateBusinessProjectAsync(CreateBusinessProjectInput input)
    {
        return _businessLineAppService.CreateBusinessProjectAsync(input);
    }

    [HttpPost("update-business-project")]
    [SwaggerOperation(summary: "编辑业务线项目", Tags = new[] { "BusinessLines" })]
    public Task<BusinessLineOutput> UpdateBusinessProjectAsync(UpdateBusinessProjectInput input)
    {
        return _businessLineAppService.UpdateBusinessProjectAsync(input);
    }

    [HttpPost("delete-business-project")]
    [SwaggerOperation(summary: "删除业务线项目", Tags = new[] { "BusinessLines" })]
    public Task DeleteBusinessProjectAsync(DeleteBusinessProjectInput input)
    {
        return _businessLineAppService.DeleteBusinessProjectAsync(input);
    }
}