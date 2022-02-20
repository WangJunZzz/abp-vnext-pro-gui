
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Lion.CodeGenerator.BusinessLines.Dto
{
    public class BusinessLineOutput : EntityDto<Guid>
    {
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

        public List<BusinessProjectOutput> BusinessProjects { get; set; }
    }

    public class BusinessProjectOutput
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 业务线名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        public string NameSpace { get; private set; }

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
