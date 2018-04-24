using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;

namespace FarmLabDevice.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));

            var assembly = typeof(MainPageViewModel).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
            {
                System.Diagnostics.Debug.WriteLine("found resource: " + res);
            }

            Title = "Welcome to FarmLab";
            ImagePathGoogle = "FarmLabDevice.Media.Images.Media/Images/google_plus_logo_128.png";
            ImagePathFaceBook = "FarmLabDevice.Media.Images.Media/Images/facebook_logo_128.png";
            ImagePathMicrosoft = "FarmLabDevice.Media.Images.Media/Images/Windows_logo_128.png";
        }

        public string Title { get; set; }
        public string ImagePathGoogle { get; set; }
        public string ImagePathFaceBook{ get; set; }
        public string ImagePathMicrosoft{ get; set; }

        public async Task ExecuteButtonFacebook()
        {
            await _navigationService.NavigateAsync("InitialFarmPage");
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public async Task ExecuteButtonGoogle()
        {
            await _navigationService.NavigateAsync("InitialFarmPage");
        }

        public async Task ExecuteButtonMicrosoft()
        {
            await _navigationService.NavigateAsync("InitialFarmPage");
        }
    }
}
