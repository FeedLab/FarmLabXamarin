using System;
using FarmLabDevice.Services;
using Prism.Navigation;

namespace FarmLabDevice.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        protected readonly INavigationService NavigationService;
        protected readonly AuthProxy AuthProxy;
        protected readonly FarmProxy FarmProxy;
        protected readonly AccountProxy AccountProxy;
        private string _title;

        public MainViewModel(INavigationService navigationService, AuthProxy authProxy, FarmProxy farmProxy, AccountProxy accountProxy)
        {
            NavigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            AuthProxy = authProxy ?? throw new ArgumentNullException(nameof(authProxy));
            FarmProxy = farmProxy ?? throw new ArgumentNullException(nameof(farmProxy));
            AccountProxy = accountProxy ?? throw new ArgumentNullException(nameof(accountProxy));

            Title = "Welcome to FarmLab";
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }
    }
}
