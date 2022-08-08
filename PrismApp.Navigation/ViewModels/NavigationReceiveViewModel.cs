using Prism.Mvvm;
using Prism.Regions;
using PrismApp.Navigation.Models;

namespace PrismApp.Navigation.ViewModels
{
    internal class NavigationReceiveViewModel : BindableBase, INavigationAware
    {
        private Person person;

        public Person Person
        {
            get { return person; }
            set { SetProperty(ref person, value); }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Person = navigationContext.Parameters["Person"] as Person;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}