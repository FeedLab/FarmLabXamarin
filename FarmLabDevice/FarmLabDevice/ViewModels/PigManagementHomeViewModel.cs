using FarmLabDevice.Model;
using Prism.Commands;
using Prism.Navigation;

namespace FarmLabDevice.ViewModels
{
    public class PigManagementHomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly UserInfo _userInfo;
        private readonly DeviceInfo _deviceInfo;

        public PigManagementHomeViewModel(INavigationService navigationService, UserInfo userInfo, DeviceInfo deviceInfo)
        {
            _navigationService = navigationService;
            _userInfo = userInfo;
            _deviceInfo = deviceInfo;

            CmdRegistration = new DelegateCommand(Execute_CmdRegistration, Can_CmdRegistration);

        }

        public FarmItem Farm { get; private set; }

        public DelegateCommand CmdRegistration { set; get; }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Farm = (FarmItem) parameters["farm"];
        }

        private bool Can_CmdRegistration()
        {
            return true;
        }

        private async void Execute_CmdRegistration()
        {
            await _deviceInfo.NavigateAsync("RegistrationHomeView");
        }
    }
}
