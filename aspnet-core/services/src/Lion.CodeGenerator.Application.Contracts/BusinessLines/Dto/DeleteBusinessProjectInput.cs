using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.CodeGenerator.BusinessLines.Dto
{
    public class DeleteBusinessProjectInput
    {
        [Required]
        public Guid BusinessLineId { get; set; }

        [Required]
        public Guid BusinessProjectId { get; set; }
    }
}
