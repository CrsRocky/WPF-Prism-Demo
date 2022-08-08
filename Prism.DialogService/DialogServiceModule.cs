using Prism.DialogService.ViewModels;
using Prism.DialogService.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace Prism.DialogService
{
    public class DialogServiceModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<DialogView, DialogViewModel>();
        }
    }
}