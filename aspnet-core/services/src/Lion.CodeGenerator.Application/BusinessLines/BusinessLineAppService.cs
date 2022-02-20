using Lion.AbpPro.Extension.Customs.Dtos;
using Lion.CodeGenerator.BusinessLines.Dto;
using Lion.CodeGenerator.BusinessLines.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Lion.CodeGenerator.BusinessLines;

public class BusinessLineAppService : CodeGeneratorAppService, IBusinessLineAppService
{
    private readonly BusinessLineManager _businessLineManager;

    public BusinessLineAppService(BusinessLineManager businessLineManager)
    {
        _businessLineManager = businessLineManager;
    }

    public async Task<PagedResultDto<BusinessLineOutput>> GetPagedListAsync(
        PagingBusinessLineListInput input, CancellationToken cancellationToken = default)
    {
        var result = new PagedResultDto<BusinessLineOutput>();

        var pagedResultDto = await _businessLineManager.GetPagedListAsync(input.Filter, input.PageSize, input.SkipCount, cancellationToken);
        result.Items = ObjectMapper.Map<List<BusinessLineDto>, List<BusinessLineOutput>>(pagedResultDto.Items?.ToList());
        result.TotalCount = pagedResultDto.TotalCount;

        return result;
    }

    public async Task<BusinessLineOutput> CreateBusinessLineAsync(CreateBusinessLineInput input)
    {
        var businessLineDto = await _businessLineManager.CreateBusinessLineAsync(input.Name, input.Description);

        return ObjectMapper.Map<BusinessLineDto, BusinessLineOutput>(businessLineDto);
    }

    public async Task<BusinessLineOutput> UpdateBusinessLineAsync(UpdateBusinessLineInput input)
    {
        var businessLineDto = await _businessLineManager.UpdateBusinessLineAsync(input.Id, input.Name, input.Description, input.Enable);

        return ObjectMapper.Map<BusinessLineDto, BusinessLineOutput>(businessLineDto);
    }

    public async Task DeleteAsync(IdInput input)
    {
        await _businessLineManager.DeleteAsync(input.Id);
    }

    public async Task<BusinessLineOutput> CreateBusinessProjectAsync(CreateBusinessProjectInput input)
    {
        var businessProjectDto = await _businessLineManager.CreateBusinessProjectAsync(input.BusinessLineId, input.Name, input.Enable, input.NameSpace, input.Description);

        return ObjectMapper.Map<BusinessLineDto, BusinessLineOutput>(businessProjectDto);
    }

    public async Task<BusinessLineOutput> UpdateBusinessProjectAsync(UpdateBusinessProjectInput input)
    {
        var businessProjectDto = await _businessLineManager.UpdateBusinessProjectAsync(input.Id, input.BusinessLineId, input.Name, input.Enable, input.NameSpace, input.Description);

        return ObjectMapper.Map<BusinessLineDto, BusinessLineOutput>(businessProjectDto);
    }

    public async Task DeleteBusinessProjectAsync(IdInput input)
    {
        await _businessLineManager.DeleteBusinessProjectAsync(input.Id);
    }
}