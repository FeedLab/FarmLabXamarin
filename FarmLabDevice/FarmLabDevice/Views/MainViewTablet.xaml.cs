using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using FarmLabDevice.Model;
using FarmLabDevice.Services;
using FarmLabDevice.ViewModels;
using Prism.Navigation;
using Xamarin.Forms;

namespace FarmLabDevice.Views
{
	[SuppressMessage("ReSharper", "PossibleNullReferenceException")]
	public partial class MainViewTablet : ContentPage
	{
	    private readonly INavigationService _navigationService;
	    private readonly DeviceInfo _deviceInfo;

	    public MainViewTablet(INavigationService navigationService, MainViewModel mainViewModel, AuthProxy authProxy, DeviceInfo deviceInfo)
		{
		    _navigationService = navigationService;
		    _deviceInfo = deviceInfo;

		    InitializeComponent();

		    BindingContext = mainViewModel;
        }

	    private void OnTapGesturePassword(object sender, EventArgs e)
	    {
	        var navigationResult = _deviceInfo.NavigateAsync("PasswordLoginView").Result;
	    }
	}
}
