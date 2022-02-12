using System;

namespace Lion.CodeGenerator.IdentityServers.Clients.Dtos
{
    public class ClientGrantTypeOutput
    {
        public Guid ClientId { get; set; }

        public string GrantType { get; set; }
    }
}