using Prism.EventAggregator.ViewModels;
using Prism.EventAggregator.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace Prism.EventAggregator
{
    public class EventAggregatorModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<EventAggregatorView, EventAggregatorViewModel>();
            containerRegistry.RegisterForNavigation<SendView, SendViewModel>();
            containerRegistry.RegisterForNavigation<ReceiveView, ReceiveViewModel>();
        }
    }
}