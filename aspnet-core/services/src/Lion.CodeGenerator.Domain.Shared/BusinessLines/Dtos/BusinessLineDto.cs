using System;
using System.Collections.Generic;

namespace Lion.CodeGenerator.BusinessLines.Dtos
{
    public class BusinessLineDto
    {
        public string Id { get; set; }

        /// <summary>
        /// 租户
        /// </summary>
        public Guid? TenantId { get;  set; }

        /// <summary>
        /// 业务线名称
        /// </summary>
        public string Name { get;  set; }

        /// <summary>
        /// 启用禁用
        /// </summary>
        public bool Enable { get;  set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get;  set; }

        public List<BusinessProjectDto> BusinessProjects { get; set; }
    }
}
