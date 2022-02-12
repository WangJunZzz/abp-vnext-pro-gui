using AutoMapper;
using Volo.Abp.AuditLogging;

namespace Lion.CodeGenerator.AuditLogs.Mappers
{
    public class AuditLogApplicationAutoMapperProfile:Profile
    {
        public AuditLogApplicationAutoMapperProfile()
        {
            CreateMap<AuditLog, GetAuditLogPageListOutput>();
        }   
    }
}