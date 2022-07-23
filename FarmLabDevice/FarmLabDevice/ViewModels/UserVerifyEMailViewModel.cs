using System;
using FarmLabDevice.Model;
using Prism.Commands;
using Prism.Navigation;

namespace FarmLabDevice.ViewModels
{
    public class UserVerifyEMailViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private UserInfo _userInfo;

        public UserVerifyEMailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));

            ContinueToLoginPage = new DelegateCommand(Execute_ContinueToLoginPage, Can_ContinueToLoginPage);
        }

        public DelegateCommand ContinueToLoginPage { set; get; }

        public string EMailAddress
        {
            get => _userInfo?.EmailAddress;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            _userInfo = parameters.GetValue<UserInfo>("UserInfo");

            RaisePropertyChanged(nameof(EMailAddress));
        }

        private bool Can_ContinueToLoginPage()
        {
            return true;
        }

        private async void Execute_ContinueToLoginPage()
        {
            await _navigationService.NavigateAsync("MainView");
        }
    }
}
