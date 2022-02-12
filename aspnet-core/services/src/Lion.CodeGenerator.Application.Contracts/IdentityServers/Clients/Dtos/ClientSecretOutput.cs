using System;

namespace Lion.CodeGenerator.IdentityServers.Clients.Dtos
{
    public class ClientSecretOutput
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

        public DateTime? Expiration { get; set; }
    }
}