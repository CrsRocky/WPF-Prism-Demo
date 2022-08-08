using Prism.Ioc;
using Prism.Modularity;
using PrismApp.Navigation.ViewModels;
using PrismApp.Navigation.Views;

namespace PrismApp.Navigation
{
    public class NavigationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationRootView, NavigationRootViewModel>();
            containerRegistry.RegisterForNavigation<NavigationParametersView, NavigationParametersViewModel>();
            containerRegistry.RegisterForNavigation<NavigationReceiveView, NavigationReceiveViewModel>();
            containerRegistry.RegisterForNavigation<NavigationRequestView, NavigationRequestViewModel>();
        }
    }
}