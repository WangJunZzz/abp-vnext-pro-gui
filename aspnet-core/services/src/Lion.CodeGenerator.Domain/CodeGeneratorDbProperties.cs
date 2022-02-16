namespace Lion.CodeGenerator
{
    public static class CodeGeneratorDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Gen_";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "LionCodeGenerator";
    }
}
