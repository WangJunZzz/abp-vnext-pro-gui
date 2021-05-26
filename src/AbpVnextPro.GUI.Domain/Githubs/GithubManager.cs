using AbpVnextPro.GUI.Domain.Exceptions;
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
        private string RepsotiryName = "abp-vnext-module-template";


        public async Task<string> GetSourceCodeAsync()
        {
            try
            {
                var resease = await GetLastReleaseInfoAsync();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "source");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var outputFullPath = Path.Combine(path, $"{RepsotiryName}-{resease.TagName}.zip");
                if (File.Exists(outputFullPath)) return outputFullPath;
                var uri = new Uri($"https://github.com/WangJunZzz/{RepsotiryName}/archive" +
                    $"/refs/tags/{resease.TagName}.zip");
                await DownloadReleaseAsync(uri, Path.Combine(path, outputFullPath));
                return outputFullPath;
            }
            catch (Exception ex)
            {

                throw new DownSourceCodeException($"{DateTime.Now.ToString() }下载源码失败：{ex.Message}");
            }
        }

        /// <summary>
        /// 获取最后一个Release信息
        /// </summary>
        /// <returns></returns>
        private Task<Release> GetLastReleaseInfoAsync()
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
        private async Task DownloadReleaseAsync(Uri uri, string SourceZipFullPath)
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
