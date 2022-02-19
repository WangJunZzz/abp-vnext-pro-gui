using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Lion.CodeGenerator.BusinessLines.Dto
{
    public class UpdateBusinessLineInput : EntityDto<Guid>
    {
        /// <summary>
        /// 业务线名称
        /// </summary>
        [Required(ErrorMessage = "业务线名称必填")]
        [MaxLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(512)]
        public string Description { get; set; }

        public bool Enable { get; set; }
    }
}
