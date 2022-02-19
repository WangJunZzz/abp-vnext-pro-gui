using System;

namespace Lion.CodeGenerator.BusinessLines.Dtos
{
    public class BusinessLineDto
    {
        public string Id { get; set; }

        /// <summary>
        /// 租户
        /// </summary>
        public Guid? TenantId { get; private set; }

        /// <summary>
        /// 业务线名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 启用禁用
        /// </summary>
        public bool Enable { get; private set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; private set; }
    }
}
