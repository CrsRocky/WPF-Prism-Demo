using Prism.Commands;
using Prism.Mvvm;
using System;

namespace Prism.CompositeCommands.ViewModels
{
    internal class PageAViewModel : BindableBase, IActiveAware
    {
        private bool _canSave;
        private readonly ICompositeSave _compositeSave;
        private string _saveDataTime;
        private bool _isActive;

        public event EventHandler IsActiveChanged;

        public string Header { get; private set; }

        public bool CanSave
        {
            get { return _canSave; }
            set { SetProperty(ref _canSave, value); }
        }

        public DelegateCommand PageASaveCommand { get; private set; }

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
            PageASaveCommand.IsActive = IsActive;
            IsActiveChanged?.Invoke(this, new EventArgs());
        }

        public PageAViewModel(ICompositeSave compositeSave)
        {
            _compositeSave = compositeSave;
            Header = "PageA";
            CanSave = true;
            PageASaveCommand = new DelegateCommand(PageASave).ObservesCanExecute(() => CanSave);
            _compositeSave.SaveCommand.RegisterCommand(PageASaveCommand);
        }

        private void PageASave()
        {
            SaveDataTime = $"Page A Save Time : {DateTime.Now}";
        }
    }
}