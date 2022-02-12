using System;

namespace Lion.CodeGenerator.IdentityServers.ApiResources.Dtos
{
    public class ApiResourceClaimOutput
    {
        public  Guid ApiResourceId { get; set; }
        
        public  string Type { get;  set; }
    }
}