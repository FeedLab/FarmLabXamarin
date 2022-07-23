using FarmLabDevice.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmLabDevice.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FarmHomeViewTablet : ContentPage
	{
	    private readonly NavigationPage _navigationPage;

	    public FarmHomeViewTablet(NavigationPage navigationPage, FarmHomeViewModel viewModel )
		{
		    _navigationPage = navigationPage;

		    InitializeComponent();

		    BindingContext = viewModel;

     //       NavigationPage.SetHasBackButton(this, true);

		    //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Black;
		    //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.OrangeRed;
        }
	}
}