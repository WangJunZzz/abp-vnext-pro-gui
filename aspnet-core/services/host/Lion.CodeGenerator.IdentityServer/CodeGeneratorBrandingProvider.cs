using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Lion.CodeGenerator
{
    [Dependency(ReplaceServices = true)]
    public class CodeGeneratorBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "CodeGenerator";
    }
}
