namespace PrismApp.Navigation.Models
{
    internal class Person : Prism.Mvvm.BindableBase
    {
        private string _name;
        private int _age;
        private string _sex;
        private string _number;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public int Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }

        public string Sex
        {
            get { return _sex; }
            set { SetProperty(ref _sex, value); }
        }

        public string Number
        {
            get => _number;
            set { _number = value; RaisePropertyChanged(); }
        }
    }
}