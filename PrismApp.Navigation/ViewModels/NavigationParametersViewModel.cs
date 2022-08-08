using Prism.Mvvm;
using Prism.Regions;
using PrismApp.Navigation.Models;
using System.Collections.ObjectModel;

namespace PrismApp.Navigation.ViewModels
{
    internal class NavigationParametersViewModel : BindableBase, INavigationAware
    {
        private ObservableCollection<Person> _peoples;

        public ObservableCollection<Person> Peoples
        {
            get { return _peoples; }
            set { SetProperty(ref _peoples, value); }
        }

        public NavigationParametersViewModel()
        {
            Peoples = new ObservableCollection<Person>
            {
                new Person { Name ="111" , Age = 11, Sex = "M", Number = "110"},
                new Person { Name ="222" , Age = 12, Sex = "W", Number = "111"},
                new Person { Name ="333" , Age = 13, Sex = "D", Number = "112"}
            };
            Person = Peoples[0];
        }

        private Person person;

        public Person Person
        {
            get { return person; }
            set { SetProperty(ref person, value); }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            navigationContext.Parameters.Add("Person", Person);
        }
    }
}