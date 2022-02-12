using System.Collections.Generic;
using System.Threading.Tasks;
using Lion.AbpPro.Extension.Customs.Dtos;
using Lion.CodeGenerator.IdentityServers.ApiScopes;
using Lion.CodeGenerator.IdentityServers.ApiScopes.Dtos;
using Lion.CodeGenerator.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Volo.Abp.Application.Dtos;

namespace Lion.CodeGenerator.Controllers.IdentityServers
{
    [Route("IdentityServer/ApiScope")]
    public class ApiScopeController : CodeGeneratorController, IApiScopeAppService
    {
        private readonly IApiScopeAppService _apiScopeAppService;

        public ApiScopeController(IApiScopeAppService apiScopeAppService)
        {
            _apiScopeAppService = apiScopeAppService;
        }

        [HttpPost("page")]
        [SwaggerOperation(summary: "分页获取ApiScope信息", Tags = new[] { "ApiScope" })]
        public Task<PagedResultDto<PagingApiScopeListOutput>> GetListAsync(
            PagingApiScopeListInput input)
        {
            return _apiScopeAppService.GetListAsync(input);
        }

        [HttpPost("create")]
        [SwaggerOperation(summary: "创建ApiScope", Tags = new[] { "ApiScope" })]
        public Task CreateAsync(CreateApiScopeInput input)
        {
            return _apiScopeAppService.CreateAsync(input);
        }

        [HttpPost("update")]
        [SwaggerOperation(summary: "更新ApiScope", Tags = new[] { "ApiScope" })]
        public Task UpdateAsync(UpdateCreateApiScopeInput input)
        {
            return _apiScopeAppService.UpdateAsync(input);
        }

        [HttpPost("delete")]
        [SwaggerOperation(summary: "删除ApiScope", Tags = new[] { "ApiScope" })]
        public Task DeleteAsync(IdInput input)
        {
            return _apiScopeAppService.DeleteAsync(input);
        }

        [HttpPost("all")]
        [SwaggerOperation(summary: "获取所有ApiScope", Tags = new[] { "ApiScope" })]
        public Task<List<FromSelector<string, string>>> FindAllAsync()
        {
            return _apiScopeAppService.FindAllAsync();
        }
    }
}