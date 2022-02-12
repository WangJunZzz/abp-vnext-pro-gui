using System.ComponentModel.DataAnnotations;

namespace Lion.CodeGenerator.IdentityServers.Clients.Dtos
{
    public class RemoveRedirectUriInput
    {
        [Required]
        public string ClientId { get; set; }
        
        [Required]
        public string Uri { get; set; }
    }
}