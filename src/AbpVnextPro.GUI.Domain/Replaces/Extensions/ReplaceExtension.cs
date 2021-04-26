using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpVnextPro.GUI.Domain.Replaces.Extensions
{
    public static class ReplaceExtension
    {
        public static string CustomReplace(this string content,string companyName,string projectName)
        {
            var result = content
                    .Replace(ReplaceConsts.OldCompanyName, companyName)
                    .Replace(ReplaceConsts.OldProjectName, projectName)
                ;

            return result;
        }
    }
}
