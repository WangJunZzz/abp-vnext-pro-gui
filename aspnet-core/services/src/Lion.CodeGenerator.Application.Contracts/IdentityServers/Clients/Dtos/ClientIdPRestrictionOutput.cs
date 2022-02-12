using System;

namespace Lion.CodeGenerator.IdentityServers.Clients.Dtos
{
    public class ClientIdPRestrictionOutput
    {
        public Guid ClientId { get; set; }

        public string Provider { get; set; }
    }
}