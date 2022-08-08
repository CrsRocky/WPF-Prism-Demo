using Prism.CompositeCommands.ViewModels;
using Prism.CompositeCommands.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace Prism.CompositeCommands
{
    public class CompositeCommandsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CompositeCommandView, CompositeCommandViewViewModel>();
            containerRegistry.RegisterForNavigation<PageAView, PageAViewModel>();
            containerRegistry.RegisterForNavigation<PageBView, PageBViewModel>();
            containerRegistry.RegisterForNavigation<PageCView, PageCViewModel>();
            containerRegistry.RegisterSingleton<ICompositeSave, Models.CompositeSave>();
        }
    }
}