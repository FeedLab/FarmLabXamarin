using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading.Tasks;
using FarmLabDevice.Managers;
using FarmLabDevice.ViewModels;
using Xamarin.Forms;

namespace FarmLabDevice.Views
{
	[SuppressMessage("ReSharper", "PossibleNullReferenceException")]
	public partial class MainPage : ContentPage
	{
	    readonly FarmLabManager _manager = new FarmLabManager();

        public MainPage()
		{
			InitializeComponent();

		    var assembly = typeof(MainPage).GetTypeInfo().Assembly;
		    foreach (var res in assembly.GetManifestResourceNames())
		    {
		        System.Diagnostics.Debug.WriteLine("found resource: " + res);
		    }
        }

	    private void Button_OnClicked(object sender, EventArgs e)
	    {
	        var userInfos = _manager.GetUserInfoItemsAsync(false).Result;
	    }

	    private async Task OnTapGestureFaceBook(object sender, EventArgs e)
	    {
	        var bindingContext = BindingContext as MainPageViewModel;

            await bindingContext.ExecuteButtonGoogle();
	    }

	    private async Task OnTapGestureGoogle(object sender, EventArgs e)
	    {
	        var bindingContext = BindingContext as MainPageViewModel;

	        await bindingContext.ExecuteButtonGoogle();
        }

        private async Task OnTapGestureMicrosoft(object sender, EventArgs e)
	    {
	        var bindingContext = BindingContext as MainPageViewModel;

	        await bindingContext.ExecuteButtonMicrosoft();
	    }
    }
}
