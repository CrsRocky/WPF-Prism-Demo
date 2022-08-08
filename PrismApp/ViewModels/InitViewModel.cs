using Prism.Mvvm;

namespace PrismApp.ViewModels
{
    internal class InitViewModel : BindableBase
    {
        private string _text = "My Init View!";

        public string Text
        {
            get => _text;
            set { _text = value; RaisePropertyChanged(); }
        }
    }
}