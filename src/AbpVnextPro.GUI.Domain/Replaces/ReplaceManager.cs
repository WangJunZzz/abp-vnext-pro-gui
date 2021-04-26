using AbpVnextPro.GUI.Domain.Exceptions;
using AbpVnextPro.GUI.Domain.Replaces.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace AbpVnextPro.GUI.Domain.Replaces
{
    public class ReplaceManager : ISingletonDependency
    {

        public void ReplaceTemplates(string sourcePath, string companyName, string projectName)
        {
            try
            {
                RenameTemplate(sourcePath, companyName, projectName);
            }
            catch (Exception ex)
            {
                throw new GenerateTemplateException($"{DateTime.Now.ToString() }生成模板失败：{ex.Message}");
            }
        }

        /// <summary>
        /// 重命名所有文件夹
        /// </summary>
        private void RenameTemplate(string sourcePath, string companyName, string projectName)
        {
            RenameAllDirectories(sourcePath, companyName, projectName);
            RenameAllFileNameAndContent(sourcePath, companyName, projectName);
        }

        private void RenameAllDirectories(string sourcePath, string companyName, string projectName)
        {
            var directories = Directory.GetDirectories(sourcePath);
            foreach (var subDirectory in directories)
            {
                RenameAllDirectories(subDirectory, companyName, projectName);

                var directoryInfo = new DirectoryInfo(subDirectory);
                if (directoryInfo.Name.Contains(ReplaceConsts.OldCompanyName) ||
                    directoryInfo.Name.Contains(ReplaceConsts.OldProjectName))
                {
                    var oldDirectoryName = directoryInfo.Name;
                    var newDirectoryName = oldDirectoryName.CustomReplace(companyName, projectName);

                    var newDirectoryPath = Path.Combine(directoryInfo.Parent?.FullName, newDirectoryName);

                    if (directoryInfo.FullName != newDirectoryPath)
                    {
                        directoryInfo.MoveTo(newDirectoryPath);
                    }
                }
            }
        }
        private void RenameAllFileNameAndContent(string sourcePath, string companyName, string projectName)
        {
            var list = new DirectoryInfo(sourcePath)
                .GetFiles()
                .Where(f => ReplaceConsts.FileFilter.Contains(f.Extension))
                .ToList();

            var encoding = new UTF8Encoding(false);
            foreach (var fileInfo in list)
            {
                // 改文件内容
                var oldContents = File.ReadAllText(fileInfo.FullName, encoding);
                var newContents = oldContents.CustomReplace(companyName, projectName);

                // 文件名包含模板关键字
                if (fileInfo.Name.Contains(ReplaceConsts.OldCompanyName)
                    || fileInfo.Name.Contains(ReplaceConsts.OldProjectName))
                {
                    var oldFileName = fileInfo.Name;
                    var newFileName = oldFileName.CustomReplace(companyName, projectName);

                    var newFilePath = Path.Combine(fileInfo.DirectoryName, newFileName);
                    // 无变化才重命名
                    if (newFilePath != fileInfo.FullName)
                    {

                        File.Delete(fileInfo.FullName);
                    }
                    File.WriteAllText(newFilePath, newContents, encoding);
                }
                else
                    File.WriteAllText(fileInfo.FullName, newContents, encoding);


            }

            foreach (var subDirectory in Directory.GetDirectories(sourcePath))
            {
                RenameAllFileNameAndContent(subDirectory, companyName, projectName);
            }
        }
    }
}
