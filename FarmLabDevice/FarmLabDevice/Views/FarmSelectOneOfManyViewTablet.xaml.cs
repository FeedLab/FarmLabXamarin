using FarmLabDevice.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmLabDevice.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FarmSelectOneOfManyViewTablet : ContentPage
	{
	    private readonly NavigationPage _navigationPage;
	    private readonly FarmSelectOneOfManyViewModel _viewModel;

        public FarmSelectOneOfManyViewTablet(NavigationPage navigationPage, FarmSelectOneOfManyViewModel viewModel)
		{
		    _navigationPage = navigationPage;
		    _viewModel = viewModel;

            InitializeComponent ();

		    BindingContext = _viewModel;

//		    NavigationPage.SetHasBackButton(this, true);
		    Appearing += View_Appearing;
        }

        private void View_Appearing(object sender, System.EventArgs e)
	    {
	        _viewModel.InitialLoad();
	    }
    }
}