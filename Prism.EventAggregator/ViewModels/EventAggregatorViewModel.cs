using Prism.Mvvm;
using Prism.Regions;

namespace Prism.EventAggregator.ViewModels
{
    public class EventAggregatorViewModel : BindableBase
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private readonly IRegionManager _regionManager;

        public EventAggregatorViewModel(IRegionManager regionManager)
        {
            Message = "View EventAggregator from your Prism Module";
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("SendRegion", "SendView");
            _regionManager.RegisterViewWithRegion("ReceiveRegion", "ReceiveView");
        }
    }
}