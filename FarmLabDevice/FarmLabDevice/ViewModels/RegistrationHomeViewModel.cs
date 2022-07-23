using Prism.Commands;
using Prism.Navigation;

namespace FarmLabDevice.ViewModels
{
    public class RegistrationHomeViewModel
    {
        private readonly INavigationService _navigationService;

        public RegistrationHomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            CmdUserManagement = new DelegateCommand(Execute_CmdUserManagement, Can_CmdUserManagement);
        }

        public DelegateCommand CmdUserManagement { set; get; }

        private bool Can_CmdUserManagement()
        {
            return true;
        }

        private async void Execute_CmdUserManagement()
        {
            await _navigationService.NavigateAsync("UserManagementView");
        }


    }
}
