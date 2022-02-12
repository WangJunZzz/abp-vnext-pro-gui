using System;

namespace Lion.CodeGenerator.IdentityServers.Clients.Dtos
{
    public class ClientCorsOriginOutput
    {
        public Guid ClientId { get; set; }

        public string Origin { get; set; }
    }
}