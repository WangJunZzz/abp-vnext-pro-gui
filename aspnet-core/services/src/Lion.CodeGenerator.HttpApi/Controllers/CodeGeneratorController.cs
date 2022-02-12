using Lion.CodeGenerator.Localization;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;

namespace Lion.CodeGenerator.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class CodeGeneratorController : AbpController
    {
        protected CodeGeneratorController()
        {
            LocalizationResource = typeof(CodeGeneratorResource);
        }
    }
}