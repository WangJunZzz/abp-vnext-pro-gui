using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using Volo.Abp.IdentityServer.IdentityResources;

namespace Lion.CodeGenerator.IdentityServer
{
    public class IdentityResourceManager : CodeGeneratorDomainService
    {
        private readonly IIdentityResourceRepository _identityResourceRepository;

        public IdentityResourceManager(IIdentityResourceRepository identityResourceRepository)
        {
            _identityResourceRepository = identityResourceRepository;
        }

        public Task<List<IdentityResource>> GetListAsync(
            int skipCount = 0,
            int maxResultCount = 10,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            return _identityResourceRepository.GetListAsync(
                "CreationTime desc",
                skipCount,
                maxResultCount,
                filter,
                includeDetails,
                cancellationToken);
        }

        public Task<List<IdentityResource>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return _identityResourceRepository.GetListAsync(true, cancellationToken);
        }

        public Task<long> GetCountAsync(string filter = null,
            CancellationToken cancellationToken = default)
        {
            return _identityResourceRepository.GetCountAsync(filter, cancellationToken);
        }


        public async Task<IdentityResource> CreateAsync(
            string name,
            string displayName,
            string description,
            bool enabled,
            bool required,
            bool emphasize,
            bool showInDiscoveryDocument)
        {
            var identityResource = await _identityResourceRepository.FindByNameAsync(name, false);
            if (null != identityResource) throw new UserFriendlyException(message: $"{name}已存在");
            identityResource = new IdentityResource(GuidGenerator.Create(), name, displayName,
                description, enabled,
                required,
                false, showInDiscoveryDocument);
            return await _identityResourceRepository.InsertAsync(identityResource);
        }

        public async Task<IdentityResource> UpdateAsync(
            string name,
            string displayName,
            string description,
            bool enabled,
            bool required,
            bool emphasize,
            bool showInDiscoveryDocument)
        {
            var identityResource = await _identityResourceRepository.FindByNameAsync(name, false);
            if (null == identityResource) throw new UserFriendlyException(message: $"{name}不存在");
            identityResource.DisplayName = displayName;
            identityResource.Description = description;
            identityResource.Enabled = enabled;
            identityResource.Required = required;
            identityResource.Emphasize = emphasize;
            identityResource.ShowInDiscoveryDocument = showInDiscoveryDocument;
            return await _identityResourceRepository.UpdateAsync(identityResource);
        }

        public Task DeleteAsync(Guid id, bool autoSave = false,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return _identityResourceRepository.DeleteAsync(id, autoSave, cancellationToken);
        }
    }
}