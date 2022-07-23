using FarmLabDevice.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmLabDevice.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationHomeViewTablet : ContentPage
	{
	    private readonly NavigationPage _navigationPage;

	    public RegistrationHomeViewTablet(NavigationPage navigationPage, RegistrationHomeViewModel mainViewModel)
		{
		    _navigationPage = navigationPage;

		    InitializeComponent();

		    BindingContext = mainViewModel;

            NavigationPage.SetHasBackButton(this, true);

		    //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Black;
		    //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.OrangeRed;
        }
	}
}