using Lion.CodeGenerator.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Lion.CodeGenerator.Settings
{
    public class CodeGeneratorSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(CodeGeneratorSettings.MySetting1));
            OverrideDefalutSettings(context);
        }

        /// <summary>
        /// 重写默认setting添加自定义属性
        /// </summary>
        private static void OverrideDefalutSettings(ISettingDefinitionContext context)
        {
            context.GetOrNull("Abp.Localization.DefaultLanguage")
                .WithProperty(CodeGeneratorSettings.Group.Default,
                    CodeGeneratorSettings.Group.SystemManagement)
                .WithProperty(CodeGeneratorSettings.ControlType.Default,
                    CodeGeneratorSettings.ControlType.TypeText);

            context.GetOrNull("Abp.Identity.Password.RequiredLength")
                .WithProperty(CodeGeneratorSettings.Group.Default,
                    CodeGeneratorSettings.Group.SystemManagement)
                .WithProperty(CodeGeneratorSettings.ControlType.Default,
                    CodeGeneratorSettings.ControlType.Number);

            context.GetOrNull("Abp.Identity.Password.RequiredUniqueChars")
                .WithProperty(CodeGeneratorSettings.Group.Default,
                    CodeGeneratorSettings.Group.SystemManagement)
                .WithProperty(CodeGeneratorSettings.ControlType.Default,
                    CodeGeneratorSettings.ControlType.Number);

            context.GetOrNull("Abp.Identity.Password.RequireNonAlphanumeric")
                .WithProperty(CodeGeneratorSettings.Group.Default,
                    CodeGeneratorSettings.Group.SystemManagement)
                .WithProperty(CodeGeneratorSettings.ControlType.Default,
                    CodeGeneratorSettings.ControlType.TypeCheckBox);

            context.GetOrNull("Abp.Identity.Password.RequireLowercase")
                .WithProperty(CodeGeneratorSettings.Group.Default,
                    CodeGeneratorSettings.Group.SystemManagement)
                .WithProperty(CodeGeneratorSettings.ControlType.Default,
                    CodeGeneratorSettings.ControlType.TypeCheckBox);

            context.GetOrNull("Abp.Identity.Password.RequireUppercase")
                .WithProperty(CodeGeneratorSettings.Group.Default,
                    CodeGeneratorSettings.Group.SystemManagement)
                .WithProperty(CodeGeneratorSettings.ControlType.Default,
                    CodeGeneratorSettings.ControlType.TypeCheckBox);

            context.GetOrNull("Abp.Identity.Password.RequireDigit")
                .WithProperty(CodeGeneratorSettings.Group.Default,
                    CodeGeneratorSettings.Group.SystemManagement)
                .WithProperty(CodeGeneratorSettings.ControlType.Default,
                    CodeGeneratorSettings.ControlType.TypeCheckBox);

            context.Add(new SettingDefinition(
                    CodeGeneratorSettings.Other.Github,
                    "https://github.com/WangJunZzz/abp-vnext-pro",
                    L("DisplayName:" + CodeGeneratorSettings.Other.Github),
                    L("Description:" + CodeGeneratorSettings.Other.Github)
                ).WithProperty(CodeGeneratorSettings.Group.Default,
                    CodeGeneratorSettings.Group.OtherManagement)
                .WithProperty(CodeGeneratorSettings.ControlType.Default,
                    CodeGeneratorSettings.ControlType.TypeText));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CodeGeneratorResource>(name);
        }
    }
}