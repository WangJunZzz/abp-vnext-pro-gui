using System.Threading.Tasks;
using Lion.CodeGenerator.BusinessLines.Dto;

namespace Lion.CodeGenerator.BusinessLines;

public class BusinessLineAppService : CodeGeneratorAppService, IBusinessLineAppService
{
    private readonly BusinessLineManager _businessLineManager;

    public BusinessLineAppService(BusinessLineManager businessLineManager)
    {
        _businessLineManager = businessLineManager;
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