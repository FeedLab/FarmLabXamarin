using FarmLabDevice.Model;
using Prism.Commands;
using Prism.Navigation;

namespace FarmLabDevice.ViewModels
{
    public class FarmHomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly UserInfo _userInfo;
        private readonly DeviceInfo _deviceInfo;

        public FarmHomeViewModel(INavigationService navigationService, UserInfo userInfo, DeviceInfo deviceInfo)
        {
            _navigationService = navigationService;
            _userInfo = userInfo;
            _deviceInfo = deviceInfo;

            CmdFeedMixManagement = new DelegateCommand(Execute_FeedMixManagement, Can_FeedMixManagement);
            CmdPigManagement = new DelegateCommand(Execute_PigManagement, Can_PigManagement);
            CmdUserManagement = new DelegateCommand(Execute_CmdUserManagement, Can_CmdUserManagement);
        }

        public FarmItem Farm { get; private set; }

        public DelegateCommand CmdFeedMixManagement { set; get; }
        public DelegateCommand CmdPigManagement { set; get; }
        public DelegateCommand CmdUserManagement { set; get; }

        public string WelcomeBackMessage
        {
            get
            {
                if(Farm != null && _userInfo != null)
                    return $"Hi {_userInfo.DisplayName} and Welcome back again to {Farm.DisplayName}";

                return "";
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Farm = (FarmItem) parameters["farm"];

            RaisePropertyChanged("WelcomeBackMessage");
        }

        private bool Can_FeedMixManagement()
        {
            return false;
        }

        private async void Execute_FeedMixManagement()
        {
            var navigationParams = new NavigationParameters { { "farm", Farm } };

            await _deviceInfo.NavigateAsync("PigManagementHomeView", navigationParams);
        }

        private bool Can_PigManagement()
        {
            return true;
        }

        private async void Execute_PigManagement()
        {
            var navigationParams = new NavigationParameters {{"farm", Farm}};

            await _deviceInfo.NavigateAsync("PigManagementHomeView", navigationParams);
        }


        private bool Can_CmdUserManagement()
        {
            return true;
        }

        private async void Execute_CmdUserManagement()
        {
            var navigationParams = new NavigationParameters { { "farm", Farm } };

            await _deviceInfo.NavigateAsync("UserManagementView", navigationParams);
        }
    }
}
