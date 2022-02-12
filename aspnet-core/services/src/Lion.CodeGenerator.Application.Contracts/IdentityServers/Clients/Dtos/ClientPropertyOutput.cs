using System;

namespace Lion.CodeGenerator.IdentityServers.Clients.Dtos
{
    public class ClientPropertyOutput
    {
        public Guid ClientId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}