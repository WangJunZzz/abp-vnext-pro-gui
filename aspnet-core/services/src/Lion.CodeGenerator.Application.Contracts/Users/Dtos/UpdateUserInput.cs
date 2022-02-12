using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Identity;

namespace Lion.CodeGenerator.Users.Dtos
{
    public class UpdateUserInput
    {
        public Guid UserId { get; set; }

        public IdentityUserUpdateDto UserInfo { get; set; }
    }
}
