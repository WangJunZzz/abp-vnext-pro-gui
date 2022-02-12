using System.Threading.Tasks;
using Lion.CodeGenerator.ElasticSearchs;
using Lion.CodeGenerator.ElasticSearchs.Dto;
using Lion.CodeGenerator.Permissions;
using Lion.AbpPro.Extension.Customs.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Lion.CodeGenerator.Controllers.Systems
{
    [Route("EsLog")]
    public class LionCodeGeneratorLogController: CodeGeneratorController,ILionCodeGeneratorLogAppService
    {
        private readonly ILionCodeGeneratorLogAppService _companyNameCodeGeneratorLogAppService;

        public LionCodeGeneratorLogController(ILionCodeGeneratorLogAppService companyNameCodeGeneratorLogAppService)
        {
            _companyNameCodeGeneratorLogAppService = companyNameCodeGeneratorLogAppService;
        }
        
        [HttpPost("page")]
        [SwaggerOperation(summary: "分页获取Es日志", Tags = new[] { "EsLog" })]
        public Task<CustomePagedResultDto<PagingElasticSearchLogOutput>> PaingAsync(PagingElasticSearchLogInput input)
        {
            return _companyNameCodeGeneratorLogAppService.PaingAsync(input);
        }
    }
}