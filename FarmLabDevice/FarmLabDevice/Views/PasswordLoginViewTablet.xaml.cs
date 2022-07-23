using System;
using FarmLabDevice.Services;
using FarmLabDevice.ViewModels;
using Prism.Navigation;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmLabDevice.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PasswordLoginViewTablet : PopupPage
    {
        private readonly INavigationService _navigationService;
        private readonly AuthProxy _authProxy;
        private readonly PasswordLoginViewModel _passwordLoginViewModel;

        public PasswordLoginViewTablet(INavigationService navigationService, AuthProxy authProxy, PasswordLoginViewModel passwordLoginViewModel)
        {
            _navigationService = navigationService;
            _authProxy = authProxy;
            _passwordLoginViewModel = passwordLoginViewModel;

            BindingContext = _passwordLoginViewModel;

            InitializeComponent ();
        }

        public void Entry_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _passwordLoginViewModel.ErrorMessage = "";
        }

        private async void Button_Cancel_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
    }
}