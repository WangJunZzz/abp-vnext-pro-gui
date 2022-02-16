using Lion.CodeGenerator.Tool.System.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Lion.CodeGenerator.Tool.System
{
    public class CodeGeneratorToolSystemModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("MainHeaderRegion", "MainHeaderView");
            regionManager.RegisterViewWithRegion("LeftMenuTreeRegion", "TreeMenuView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<MainHeaderView>();
            containerRegistry.Register<TreeMenuView>();
        }
    }
}
