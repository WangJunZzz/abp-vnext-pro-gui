using AbpVnextPro.GUI.Domain.Exceptions;
using System;
using System.IO;
using System.IO.Compression;
using Volo.Abp.DependencyInjection;

namespace AbpVnextPro.GUI.Domain.Zips
{
    public class ZipManager : ISingletonDependency
    {
        public string ExtractZips(string sourceZipFullPath, string commpanyName, string projectName)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "code",commpanyName+projectName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var decompressionPath = Path.Combine(path, Path.GetFileNameWithoutExtension(sourceZipFullPath));
                if (Directory.Exists(decompressionPath)) return decompressionPath;
                ZipFile.ExtractToDirectory(sourceZipFullPath, path);
                return decompressionPath;
            }
            catch (Exception ex)
            {
                throw new ZipException($"{DateTime.Now.ToString() }解压源码失败:{ex.Message}");
            }

        }

    }
}
