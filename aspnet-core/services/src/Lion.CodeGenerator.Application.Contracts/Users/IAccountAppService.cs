
using System.Threading.Tasks;
using Lion.CodeGenerator.Users.Dtos;
using Volo.Abp.Application.Services;



namespace Lion.CodeGenerator.Users
{
    public interface IAccountAppService: IApplicationService
    {
        Task<LoginOutput> LoginAsync(LoginInput input);

        Task<LoginOutput> StsLoginAsync(string accessToken);
  
    }
}
