using System;

namespace Lion.CodeGenerator.BusinessLines.Dtos
{
    public class BusinessProjectDto
    {

        public Guid Id { get; set; }
        /// <summary>
        /// 业务线名称
        /// </summary>
        public string Name { get;  set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        public string NameSpace { get;  set; }

        /// <summary>
        /// 启用禁用
        /// </summary>
        public bool Enable { get;  set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get;  set; }
    }
}
