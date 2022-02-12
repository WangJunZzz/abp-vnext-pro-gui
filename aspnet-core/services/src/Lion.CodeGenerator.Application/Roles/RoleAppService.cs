using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lion.CodeGenerator.Roles.Dtos;
using Lion.AbpPro.Extension.Customs.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace Lion.CodeGenerator.Roles
{
    [Authorize(Policy = IdentityPermissions.Roles.Default)]
    public class RoleAppService : CodeGeneratorAppService, IRoleAppService
    {
        private readonly IIdentityRoleAppService _identityRoleAppService;

        private readonly IIdentityRoleRepository _roleRepository;

        public RoleAppService(
            IIdentityRoleAppService identityRoleAppService,
            IIdentityRoleRepository roleRepository)
        {
            _identityRoleAppService = identityRoleAppService;

            _roleRepository = roleRepository;
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        public async Task<ListResultDto<IdentityRoleDto>> AllListAsync()
        {
            List<IdentityRole> source =
                await _roleRepository.GetListAsync()
                    .ConfigureAwait(continueOnCapturedContext: false);
            return new ListResultDto<IdentityRoleDto>(
                base.ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(source));
        }

        /// <summary>
        /// 分页查询角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<IdentityRoleDto>> ListAsync(PagingRoleListInput input)
        {
            var request = new GetIdentityRolesInput
            {
                Filter = input.Filter?.Trim(), MaxResultCount = input.PageSize,
                SkipCount = input.SkipCount
            };
            List<IdentityRole> list = await _roleRepository
                .GetListAsync(request.Sorting, request.MaxResultCount, request.SkipCount,
                    request.Filter)
                .ConfigureAwait(continueOnCapturedContext: false);
            return new PagedResultDto<IdentityRoleDto>(
                await _roleRepository.GetCountAsync(request.Filter)
                    .ConfigureAwait(continueOnCapturedContext: false),
                base.ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(list));
        }


        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(IdentityPermissions.Roles.Create)]
        public async Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateDto input)
        {
            return await _identityRoleAppService.CreateAsync(input);
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(IdentityPermissions.Roles.Update)]
        public async Task<IdentityRoleDto> UpdateAsync(UpdateRoleInput input)
        {
            return await _identityRoleAppService.UpdateAsync(input.RoleId, input.RoleInfo);
        }


        /// <summary>
        /// 删除角色
        /// </summary>
        [Authorize(IdentityPermissions.Roles.Delete)]
        public async Task DeleteAsync(IdInput input)
        {
            await _identityRoleAppService.DeleteAsync(input.Id);
        }
    }
}