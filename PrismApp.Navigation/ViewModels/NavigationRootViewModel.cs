using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace PrismApp.Navigation.ViewModels
{
    [RegionMemberLifetime(KeepAlive = true)]
    public class NavigationRootViewModel : BindableBase
    {
        private IRegionManager _regionManager;

        //private IRegionNavigationService navigationService;
        private IRegionNavigationJournal _journal;

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public string NavigationParameters { get; set; }
        public string NavigationReceive { get; set; }
        public string NavigationRequest { get; set; }

        public DelegateCommand<string> NavigationCommand { get; private set; }
        public DelegateCommand GoBackCommand { get; private set; }
        public DelegateCommand GoForwardCommand { get; private set; }
        public DelegateCommand ClearJournal { get; private set; }

        public NavigationRootViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            Message = "Navigation Root from your Prism Module";
            NavigationParameters = nameof(NavigationParameters);
            NavigationReceive = nameof(NavigationReceive);
            NavigationRequest = nameof(NavigationRequest);
            NavigationCommand = new DelegateCommand<string>(Navigation);
            //在属性值更改时命令应该发送通知的情况下，您可以使用该ObservesProperty方法。
            //使用该ObservesProperty方法时，每当提供的属性值发生变化时，DelegateCommand都会自动调用RaiseCanExecuteChanged以通知 UI 状态变化。
            //如果您CanExecute是简单Boolean属性的结果，则可以消除声明CanExecute委托的需要，ObservesCanExecute而是使用该方法。
            //ObservesCanExecute不仅会在注册的属性值更改时向 UI 发送通知，而且还会使用与实际CanExecute委托相同的属性。
            GoBackCommand = new DelegateCommand(GoBack, CanGoBack);
            GoForwardCommand = new DelegateCommand(GoForward, CanGoForward);
            //GoForwardCommand = new DelegateCommand(GoForward).ObservesCanExecute(() => CanGoForward());
            ClearJournal = new DelegateCommand(Clear);
        }

        private void Navigation(string content)
        {
            content = $"{content}View";
            _regionManager.Regions["NavigationContent"].RequestNavigate(content, navigationCallback =>
            {
                if ((bool)navigationCallback.Result)
                {
                    _journal = navigationCallback.Context.NavigationService.Journal;
                    Refresh();
                }
                else
                {
                }
            });
        }

        private void Refresh()
        {
            GoBackCommand.RaiseCanExecuteChanged();
            GoForwardCommand.RaiseCanExecuteChanged();
        }

        private void GoBack()
        {
            _journal.GoBack();
            Refresh();
        }

        private bool CanGoBack()
        {
            return _journal != null && _journal.CanGoBack;
        }

        private void GoForward()
        {
            _journal.GoForward();
            Refresh();
        }

        private bool CanGoForward()
        {
            return _journal != null && _journal.CanGoForward;
        }

        private void Clear()
        {
            _journal.Clear();
            //Refresh();
        }
    }
}