using Microsoft.Extensions.Logging;
using Octokit;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpVnextPro.GUI.Domain.Githubs
{
    public class GithubManager : ITransientDependency
    {
        private string Owner = "WangJunZzz";
        private string RepsotiryName = "abp-vnext-pro";

        /// <summary>
        /// 获取最后一个Release信息
        /// </summary>
        /// <returns></returns>
        public Task<Release> GetLastReleaseInfoAsync()
        {
            var github = new GitHubClient(new ProductHeaderValue(RepsotiryName));
            return github.Repository.Release.GetLatest(Owner, RepsotiryName);

        }

        /// <summary>
        /// 下载源码
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="SourceZipFullPath"></param>
        /// <returns></returns>
        public async Task DownloadReleaseAsync(Uri uri, string SourceZipFullPath)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                using (FileStream fileStream = new FileStream(SourceZipFullPath, System.IO.FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await response.Content.CopyToAsync(fileStream);
                }
            }
        }
    }
}
