using System.Collections.Generic;

namespace Lion.CodeGenerator;

public static class DataTypeConsts
{
    public const string CodeString = "string";
    public const string CodeGuid = "Guid";
    public const string CodeDateTime = "DateTime";
    public const string CodeBool = "bool";
    public const string CodeInt = "int";
    public const string CodeLong = "long";
    public const string CodeDecimal = "decimal";
    public const string CodeEumn = "eumn";

    public static List<string> ToList()
    {
        return new List<string>()
        {
            CodeString,
            CodeGuid,
            CodeDecimal,
            CodeBool,
            CodeInt,
            CodeLong,
            CodeDecimal,
            CodeEumn
        };
    }
}