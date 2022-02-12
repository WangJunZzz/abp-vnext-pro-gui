using System;

namespace Lion.CodeGenerator.IdentityServers.Clients.Dtos
{
    public class ClientClaimOutput
    {
        public Guid ClientId { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }
    }
}