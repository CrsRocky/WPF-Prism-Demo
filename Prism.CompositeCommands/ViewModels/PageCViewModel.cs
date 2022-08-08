using Prism.Commands;
using Prism.Mvvm;
using System;

namespace Prism.CompositeCommands.ViewModels
{
    internal class PageCViewModel : BindableBase
    {
        private readonly ICompositeSave _compositeSave;
        private string _saveDataTime;
        private bool _canSave;

        public string Header { get; private set; }

        public bool CanSave
        {
            get { return _canSave; }
            set { SetProperty(ref _canSave, value); }
        }

        public DelegateCommand PageCSaveCommand { get; private set; }

        public string SaveDataTime
        {
            get { return _saveDataTime; }
            set { SetProperty(ref _saveDataTime, value); }
        }

        public PageCViewModel(ICompositeSave compositeSave)
        {
            _compositeSave = compositeSave;
            Header = "PageC";
            CanSave = true;
            PageCSaveCommand = new DelegateCommand(PageCSave).ObservesCanExecute(() => CanSave);
            PageCSaveCommand.IsActive = true;
            _compositeSave.SaveCommand.RegisterCommand(PageCSaveCommand);
        }

        private void PageCSave()
        {
            SaveDataTime = $"Page C Save Time : {DateTime.Now}";
        }
    }
}