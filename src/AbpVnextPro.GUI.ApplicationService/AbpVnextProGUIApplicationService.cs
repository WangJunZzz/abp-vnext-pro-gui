using AbpVnextPro.GUI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace AbpVnextPro.GUI.ApplicationService
{
    [DependsOn(typeof(AbpVnextProGUIDomainModule))]
    public class AbpVnextProGUIApplicationService:AbpModule
    {

    }
}
