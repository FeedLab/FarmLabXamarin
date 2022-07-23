using FarmLabDevice.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmLabDevice.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PigManagementHomeViewTablet : ContentPage
	{
	    private readonly NavigationPage _navigationPage;

	    public PigManagementHomeViewTablet(NavigationPage navigationPage, PigManagementHomeViewModel mainViewModel)
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