using FarmLabDevice.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmLabDevice.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserManagementViewTablet : ContentPage
	{
	    private readonly NavigationPage _navigationPage;
	    private readonly UserManagementViewModel _viewModel;

        public UserManagementViewTablet(NavigationPage navigationPage, UserManagementViewModel viewModel)
		{
		    _navigationPage = navigationPage;
		    _viewModel = viewModel;

		    InitializeComponent();

		    BindingContext = _viewModel;

		    NavigationPage.SetHasBackButton(this, true);

            this.Appearing += UserManagementView_Appearing;
		    //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Black;
		    //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.OrangeRed;
        }

        private void UserManagementView_Appearing(object sender, System.EventArgs e)
        {
            _viewModel.InitialLoad();
        }
    }
}