using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmLabDevice.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserVerifyEMailView : ContentPage
	{
	    private readonly NavigationPage _navigationPage;

	    public UserVerifyEMailView(NavigationPage navigationPage)
		{
		    _navigationPage = navigationPage;

		    InitializeComponent();
		    Title = "FarmLab want you to verify your identity";


//		    NavigationPage.SetHasBackButton(this, true);

		    //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Black;
		    //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.OrangeRed;
        }
	}
}