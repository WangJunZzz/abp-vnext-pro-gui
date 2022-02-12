using System;
using System.Collections.Generic;
using System.Text;
using Lion.CodeGenerator.Localization;
using Volo.Abp.Application.Services;
using Volo.Abp.Localization;

namespace Lion.CodeGenerator
{
    /* Inherit your application services from this class.
     */
    public abstract class CodeGeneratorAppService : ApplicationService
    {
        protected CodeGeneratorAppService()
        {
            LocalizationResource = typeof(CodeGeneratorResource);
        }
    }
}
