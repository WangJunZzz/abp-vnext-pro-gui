using AutoMapper;
using Lion.CodeGenerator.Users.Dtos;

namespace Lion.CodeGenerator.Users.Mappers
{
    public class UserApplicationAutoMapperProfile:Profile
    {
        public UserApplicationAutoMapperProfile()
        {
            CreateMap<Volo.Abp.Identity.IdentityUser, LoginOutput>();
        }
    }
}