using AbpVnextPro.GUI.Domain.Githubs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpVnextPro.GUI.ApplicationService.Generates
{
    public class GenerateAppService: ITransientDependency
    {
        public readonly GithubManager _githubManager;

        public GenerateAppService(GithubManager githubManager)
        {
            _githubManager = githubManager;
        }


        public async Task GenerateSourceAsync()
        {
            var releae = await _githubManager.GetLastReleaseInfoAsync();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "source",$"abp-vnext-pro-{releae.TagName}.zip");
            var uri = new Uri($"https://github.com/WangJunZzz/abp-vnext-pro/archive/refs/tags/{releae.TagName}.zip");
            await _githubManager.DownloadReleaseAsync(uri, path);
        }
    }
}
