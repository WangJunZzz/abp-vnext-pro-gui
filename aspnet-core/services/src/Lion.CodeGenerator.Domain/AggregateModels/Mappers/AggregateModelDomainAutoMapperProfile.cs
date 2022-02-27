using AutoMapper;
using Lion.CodeGenerator.AggregateModels.Aggregates;
using Lion.CodeGenerator.AggregateModels.Dto;

namespace Lion.CodeGenerator.AggregateModels.Mappers
{
    public class AggregateModelDomainAutoMapperProfile : Profile
    {
        public AggregateModelDomainAutoMapperProfile()
        {
            CreateMap<AggregateModel, AggregateModelDto>();
            CreateMap<EntityModel, EntityModelDto>();
            CreateMap<PropertyModel, PropertyModelDto>();
        }
    }
}