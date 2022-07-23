using FarmLabDevice.Model;
using FarmLabDevice.Services;
using Prism.Commands;
using Prism.Navigation;

namespace FarmLabDevice.ViewModels
{
    public class FarmSetupFirstViewModel : ViewModelBase
    {
        private readonly FarmProxy _farmProxy;
        private readonly INavigationService _navigationService;
        private string _farmDescription;
        private string _farmName;

        public FarmSetupFirstViewModel(FarmProxy farmProxy, INavigationService navigationService)
        {
            _farmProxy = farmProxy;
            _navigationService = navigationService;
            _farmName = "My Awesome Farm";
            _farmDescription = "";

            CreateFarm = new DelegateCommand(Execute_CreateFarm, Can_CreateFarm);
        }

        public DelegateCommand CreateFarm { set; get; }

        public string FarmName
        {
            get => _farmName;
            set
            {
                _farmName = value;
                RaisePropertyChanged();

                CreateFarm.RaiseCanExecuteChanged();
            }
        }

        public string FarmDescription
        {
            get => _farmDescription;
            set
            {
                _farmDescription = value;
                RaisePropertyChanged();
            }
        }

        private bool Can_CreateFarm()
        {

            if (_farmName.Length > 0)
            {
                return true;
            }

            return false;
        }

        private async void Execute_CreateFarm()
        {
            var farmModel = new CreateFarmModel { DisplayName = FarmName, Description = FarmDescription };
            var farmItem = await _farmProxy.CreateFarm(farmModel);

            if (farmItem != null)
            {
                var navigationParams = new NavigationParameters();
                navigationParams.Add("farm", farmItem);
                await _navigationService.NavigateAsync("FarmHomeView", navigationParams);
            }
        }
    }
}
