using AbpVnextPro.GUI.Domain.Githubs;
using AbpVnextPro.GUI.Domain.Replaces;
using AbpVnextPro.GUI.Domain.Zips;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpVnextPro.GUI.ApplicationService.Generates
{
    public class GenerateAppService : ITransientDependency
    {
        public readonly GithubManager _githubManager;
        private readonly ZipManager _zipManager;
        private readonly ReplaceManager _replaceManager;
        public GenerateAppService(GithubManager githubManager, ZipManager zipManager, ReplaceManager replaceManager)
        {
            _githubManager = githubManager;
            _zipManager = zipManager;
            _replaceManager = replaceManager;
        }


        public async Task<string> DownloadSourceAsync(string type)
        {
            return await _githubManager.GetSourceCodeAsync(type);
        }

        public string ExtractZips(string path,string commpanyName,string projectName)
        {
            return _zipManager.ExtractZips(path, commpanyName, projectName);
        }

        public void GenerateTemplate(string path, string companyName, string projectName)
        {
            _replaceManager.ReplaceTemplates(path, companyName, projectName);
        }
    }
}
