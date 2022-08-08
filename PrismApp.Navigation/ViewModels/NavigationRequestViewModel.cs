using Prism.Regions;
using System;
using System.Windows;

namespace PrismApp.Navigation.ViewModels
{
    internal class NavigationRequestViewModel : IConfirmNavigationRequest
    {
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool result = true;

            // this is demo code only and not suitable for production. It is generally
            // poor practice to reference your UI in the view model. Use the Prism
            // IDialogService to help with this.
            if (MessageBox.Show("Do you to navigate?", "Navigate?", MessageBoxButton.YesNo) == MessageBoxResult.No)
                result = false;
            continuationCallback(result);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
    }
}