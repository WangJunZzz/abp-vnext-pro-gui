using System;

namespace Lion.CodeGenerator.IdentityServers.Clients.Dtos
{
    public class ClientScopeOutput
    {
        public Guid ClientId { get; set; }

        public string Scope { get; set; }
    }
}