using Lion.CodeGenerator.Localization;

namespace Lion.CodeGenerator
{
    public abstract class CodeGeneratorDomainTestBase : CodeGeneratorTestBase<CodeGeneratorDomainTestModule> 
    {
        public CodeGeneratorDomainTestBase()
        {
            ServiceProvider.InitializeLocalization();;
        }
    }
}
