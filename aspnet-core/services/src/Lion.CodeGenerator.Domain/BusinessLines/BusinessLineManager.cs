using Volo.Abp.Domain.Services;

namespace Lion.CodeGenerator.BusinessLines;

public class BusinessLineManager : DomainService
{
    private readonly IBusinessLineRepository _businessLineRepository;

    public BusinessLineManager(IBusinessLineRepository businessLineRepository)
    {
        _businessLineRepository = businessLineRepository;
    }
}