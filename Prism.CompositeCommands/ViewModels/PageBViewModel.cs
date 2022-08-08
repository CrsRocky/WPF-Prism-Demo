using Prism.Commands;
using Prism.Mvvm;
using System;

namespace Prism.CompositeCommands.ViewModels
{
    internal class PageBViewModel : BindableBase, IActiveAware
    {
        private bool _canSave;
        private readonly ICompositeSave _compositeSave;
        private string _saveDataTime;
        private bool _isActive;

        public string Header { get; private set; }

        public bool CanSave
        {
            get { return _canSave; }
            set { SetProperty(ref _canSave, value); }
        }

        public DelegateCommand PageBSaveCommand { get; private set; }

        public string SaveDataTime
        {
            get { return _saveDataTime; }
            set { SetProperty(ref _saveDataTime, value); }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                OnIsActiveChanged();
            }
        }

        private void OnIsActiveChanged()
        {
            PageBSaveCommand.IsActive = IsActive;
            IsActiveChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler IsActiveChanged;

        public PageBViewModel(ICompositeSave compositeSave)
        {
            _compositeSave = compositeSave;
            Header = "PageB";
            CanSave = true;
            PageBSaveCommand = new DelegateCommand(PageBSave).ObservesCanExecute(() => CanSave);
            _compositeSave.SaveCommand.RegisterCommand(PageBSaveCommand);
        }

        private void PageBSave()
        {
            SaveDataTime = $"Page B Save Time : {DateTime.Now}";
        }
    }
}