using Prism.CompositeCommands;
using Prism.DialogService;
using Prism.EventAggregator;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using PrismApp.Navigation;
using PrismApp.ViewModels;
using PrismApp.Views;
using System.Windows;

namespace PrismApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
            ViewModelLocationProvider.Register<InitView, InitViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<NavigationModule>();
            moduleCatalog.AddModule<CompositeCommandsModule>();
            moduleCatalog.AddModule<EventAggregatorModule>();
            moduleCatalog.AddModule<DialogServiceModule>();
            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}