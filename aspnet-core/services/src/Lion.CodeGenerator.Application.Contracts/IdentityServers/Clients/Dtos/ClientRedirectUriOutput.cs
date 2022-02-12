using System;

namespace Lion.CodeGenerator.IdentityServers.Clients.Dtos
{
    public class ClientRedirectUriOutput
    {
        public virtual Guid ClientId { get; set; }

        public virtual string RedirectUri { get; set; }
    }
}