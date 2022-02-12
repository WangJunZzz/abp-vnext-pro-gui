using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lion.CodeGenerator.Localization;
using Lion.CodeGenerator.Permissions;
using Lion.CodeGenerator.Settings.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

namespace Lion.CodeGenerator.Settings
{
    [Authorize(policy: CodeGeneratorPermissions.SystemManagement.Setting)]
    public class SettingAppService : CodeGeneratorAppService, ISettingAppService
    {
        private readonly ISettingDefinitionManager _settingDefinitionManager;
        private readonly ISettingManager _settingManager;
        private readonly IStringLocalizer<CodeGeneratorResource> _localizer;
        private readonly IStringLocalizerFactory _factory;

        public SettingAppService(
            ISettingDefinitionManager settingDefinitionManager,
            ISettingManager settingManager,
            IStringLocalizer<CodeGeneratorResource> localizer,
            IStringLocalizerFactory factory)
        {
            _settingDefinitionManager = settingDefinitionManager;
            _settingManager = settingManager;
            _localizer = localizer;
            _factory = factory;
        }

        public async Task<List<SettingOutput>> GetAsync()
        {
            var allSettings = _settingDefinitionManager.GetAll().ToList();
            var settings = allSettings
                .Where(e => e.Properties.ContainsKey(CodeGeneratorSettings.Group.Default)).ToList();

            var settingOutput = settings
                .GroupBy(e => e.Properties[CodeGeneratorSettings.Group.Default].ToString()).Select(s =>
                    new SettingOutput
                    {
                        Group = s.Key,
                        GroupDisplayName = _localizer[s.Key]
                    }).ToList();

            foreach (var item in settingOutput)
            {
                var currentSettings = settings.Where(e => e.Properties.ContainsValue(item.Group));
                foreach (var itemDefinition in currentSettings)
                {
                  
                    var value = await SettingProvider.GetOrNullAsync(itemDefinition.Name);
                    var type = itemDefinition.Properties
                        .FirstOrDefault(f => f.Key == CodeGeneratorSettings.ControlType.Default).Value
                        .ToString();
                    
                    item.SettingItemOutput.Add(new SettingItemOutput(
                        itemDefinition.Name,
                        itemDefinition.DisplayName.Localize(_factory),
                        value,
                        type,
                        itemDefinition.Description.Localize(_factory)));
                }
            }

            return await Task.FromResult(settingOutput);
        }

        public async Task UpdateAsync(UpdateSettingInput input)
        {
            foreach (var kv in input.Values)
            {
                // The key of the settingValues is in camel_Case, like "setting_Abp_Localization_DefaultLanguage",
                // change it to "Abp.Localization.DefaultLanguage" form
                if (!kv.Key.StartsWith(CodeGeneratorSettings.Prefix))
                {
                    continue;
                }

                string name = kv.Key.RemovePreFix(CodeGeneratorSettings.Prefix);
                var setting = _settingDefinitionManager.GetOrNull(name);
                if (setting == null)
                {
                    continue;
                }

                await SetSetting(setting, kv.Value);
            }
        }

        private Task SetSetting(SettingDefinition setting, string value)
        {
            if (setting.Providers.Any(p => p == UserSettingValueProvider.ProviderName))
            {
                return _settingManager.SetForCurrentUserAsync(setting.Name, value);
            }

            if (setting.Providers.Any(p => p == GlobalSettingValueProvider.ProviderName))
            {
                return _settingManager.SetGlobalAsync(setting.Name, value);
            }

            //Default
            return _settingManager.SetForCurrentTenantAsync(setting.Name, value);
        }
    }
}