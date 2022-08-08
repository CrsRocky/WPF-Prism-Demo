using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Prism.CompositeCommands.ViewModels
{
    internal class CompositeCommandViewViewModel : BindableBase
    {
        private IRegionManager _regionManager;

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private ICompositeSave _compositeSave;

        public ICompositeSave CompositeSave
        {
            get { return _compositeSave; }
            set { SetProperty(ref _compositeSave, value); }
        }

        public DelegateCommand<string> PageChangedCommand { get; private set; }

        public CompositeCommandViewViewModel(ICompositeSave compositeSave, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            CompositeSave = compositeSave;
            Message = "CompositeCommand View from your Prism Module";
            _regionManager.RegisterViewWithRegion("TabControlRegion", "PageAView");
            _regionManager.RegisterViewWithRegion("TabControlRegion", "PageBView");
            _regionManager.RegisterViewWithRegion("TabControlRegion", "PageCView");
            PageChangedCommand = new DelegateCommand<string>(PageChanged);
        }

        private void PageChanged(string pageHeader)
        {
            //_regionManager.Regions["TabControlRegion"].RequestNavigate($"{pageHeader}View", c => { Trace.WriteLine(c.Result); });
        }
    }
}