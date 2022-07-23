using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading.Tasks;
using FarmLabDevice.Services;
using FarmLabDevice.ViewModels;
using Prism.Navigation;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace FarmLabDevice.Views
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public partial class MainView : ContentPage
    {
        private readonly INavigationService _navigationService;
        private readonly PasswordLoginViewTablet _passwordLoginView;

        public MainView(INavigationService navigationService, AuthProxy authProxy, PasswordLoginViewModel passwordLoginViewModel)
        {
            _navigationService = navigationService;

            InitializeComponent();

            var assembly = typeof(MainView).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
            {
                System.Diagnostics.Debug.WriteLine("found resource: " + res);
            }

            _passwordLoginView = new PasswordLoginViewTablet(navigationService, authProxy, passwordLoginViewModel);
        }

        private async Task OnTapGesturePassword(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(_passwordLoginView);
        }
    }
}
