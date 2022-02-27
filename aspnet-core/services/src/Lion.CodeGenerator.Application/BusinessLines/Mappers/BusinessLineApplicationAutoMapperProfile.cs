using AutoMapper;
using Lion.CodeGenerator.BusinessLines.Dto;
using Lion.CodeGenerator.BusinessLines.Dtos;

namespace Lion.CodeGenerator.BusinessLines.Mappers
{
    public class BusinessLineApplicationAutoMapperProfile : Profile
    {
        public BusinessLineApplicationAutoMapperProfile()
        {
            CreateMap<BusinessLineDto, BusinessLineOutput>();
            CreateMap<BusinessProjectDto, BusinessProjectOutput>();
        }
        
    }
}