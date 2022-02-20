﻿using System;

namespace Lion.CodeGenerator.BusinessLines.Dto
{
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
