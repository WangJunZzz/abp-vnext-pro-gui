using System;

namespace Lion.CodeGenerator.IdentityServers.Clients.Dtos
{
    public class ClientPostLogoutRedirectUriOutput
    {
        public Guid ClientId { get; set; }

        public string PostLogoutRedirectUri { get; set; }
    }
}