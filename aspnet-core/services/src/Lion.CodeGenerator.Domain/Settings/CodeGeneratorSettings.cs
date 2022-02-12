namespace Lion.CodeGenerator.Settings
{
    public static class CodeGeneratorSettings
    {
        public const string Prefix = "setting_";

        /// <summary>
        /// 前端控件类型
        /// </summary>
        public static class ControlType
        {
            public const string Default = "Type";
            public const string TypeText = "Text";
            public const string TypeCheckBox = "CheckBox";
            public const string Number = "Number";
        }

        /// <summary>
        /// 系统控制分组
        /// </summary>
        public static class Group
        {
            public const string Default = "Setting.Group";
            public const string SystemManagement = Default + ".System";
            public const string OtherManagement = Default + ".Other";
        }

        /// <summary>
        /// 其他控制分组
        /// </summary>
        public static class Other
        {
            private const string Default = "Setting.Group.Other";
            public const string Github = Default + ".Github";
        }
    }
}