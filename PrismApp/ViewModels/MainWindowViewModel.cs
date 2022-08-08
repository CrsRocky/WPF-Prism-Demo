using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PrismApp.Views;

namespace PrismApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private readonly IDialogService _dialogService;
        private string _title = "My Prism Application Demo";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand<string> NavigationCommand { get; private set; }
        public DelegateCommand DialogCommand { get; private set; }
        //private readonly Object _initView = new InitView() { DataContext = new InitViewModel()};

        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            this.regionManager = regionManager;
            _dialogService = dialogService;
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(InitView));
            NavigationCommand = new DelegateCommand<string>(Navigation);
            DialogCommand = new DelegateCommand(ShowDialog);
            //regionManager.RegisterViewWithRegion("ContentRegion", () => { return _initView; });
            //regionManager.RegisterViewWithRegion("ContentRegion", () => containerProvider.Resolve<InitView>());
        }

        private void Navigation(string content)
        {
            regionManager.Regions["ContentRegion"].RequestNavigate($"{content}View");
        }

        private void ShowDialog()
        {
            var message = "This is a message that should be shown in the dialog.";
            //using the dialog service as-is
            _dialogService.ShowDialog("DialogView", new DialogParameters($"message={message}"), r =>
            {
                if (r.Result == ButtonResult.None)
                    Title = "Result is None";
                else if (r.Result == ButtonResult.OK)
                    Title = "Result is OK";
                else if (r.Result == ButtonResult.Cancel)
                    Title = "Result is Cancel";
                else
                    Title = "I Don't know what you did!?";
            });
        }
    }
}