using Lion.CodeGenerator.Tool.Views;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Serilog;
using Serilog.Events;
using System;
using System.Windows;
using Volo.Abp;

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
            if (Container.Resolve<LoginWin>().ShowDialog() == false)
                Current.Shutdown();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = Environment.CurrentDirectory + "\\Modules" };
        }

        private IAbpApplicationWithInternalServiceProvider _abpApplication;
        protected async override void OnStartup(StartupEventArgs e)
        {
            Log.Logger = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Async(c => c.File("Logs/logs.txt"))
                .CreateLogger();

            try
            {
                Log.Information("Starting WPF host.");

                _abpApplication = await AbpApplicationFactory.CreateAsync<CodeGeneratorToolModule>(options =>
                {
                    options.UseAutofac();
                    options.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
                });

                await _abpApplication.InitializeAsync();

                _abpApplication.Services.GetRequiredService<LoginWin>()?.Show();

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly!");
            }
        }

        protected async override void OnExit(ExitEventArgs e)
        {
            await _abpApplication.ShutdownAsync();
            Log.CloseAndFlush();
        }
    }
}