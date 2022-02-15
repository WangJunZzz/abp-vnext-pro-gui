using Lion.CodeGenerator.Tool.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Windows;


namespace Lion.CodeGenerator.Tool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            if (Container.Resolve<LoginView>().ShowDialog() == false)
                Current.Shutdown();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = Environment.CurrentDirectory + "\\Modules" };
        }
    }
}
