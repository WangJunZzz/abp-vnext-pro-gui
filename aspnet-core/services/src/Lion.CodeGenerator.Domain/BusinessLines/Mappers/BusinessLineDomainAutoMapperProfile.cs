using AutoMapper;
using Lion.CodeGenerator.BusinessLines.Aggregates;
using Lion.CodeGenerator.BusinessLines.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lion.CodeGenerator.BusinessLines.Mappers
{
    public class BusinessLineDomainAutoMapperProfile : Profile
    {
        public BusinessLineDomainAutoMapperProfile()
        {
            CreateMap<BusinessLine, BusinessLineDto>();
            CreateMap<BusinessProject, BusinessProjectDto>();
        }
    }
}
