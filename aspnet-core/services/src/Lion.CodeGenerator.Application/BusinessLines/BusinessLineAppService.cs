using System.Threading.Tasks;
using Lion.AbpPro.Extension.Customs.Dtos;
using Lion.CodeGenerator.BusinessLines.Dto;

namespace Lion.CodeGenerator.BusinessLines;

public class BusinessLineAppService : CodeGeneratorAppService, IBusinessLineAppService
{
    private readonly BusinessLineManager _businessLineManager;

    public BusinessLineAppService(BusinessLineManager businessLineManager)
    {
        _businessLineManager = businessLineManager;
    }

    public Task<CustomePagedResultDto<PagingBusinessLineOutput>> PagingAsync(PagingBusinessLineInput input)
    {
        return _businessLineManager.PagingAsync(input);
    }

    public Task CreateBusinessLineAsync(CreateBusinessLineInput input)
    {
        return _businessLineManager.CreateBusinessLineAsync(input.Name, input.Description);
    }

    public Task CreateBusinessProjectAsync(CreateBusinessProjectInput input)
    {
        return _businessLineManager.CreateBusinessProjectAsync(input.BusinessLineId, input.Name, input.NameSpace, input.Description);
    }
}