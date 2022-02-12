using System;

namespace Lion.CodeGenerator.IdentityServers.ApiResources.Dtos
{
    public class ApiResourceScopeOutput
    {
        public Guid ApiResourceId { get; set; }

        public string Scope { get; set; }
    }
}