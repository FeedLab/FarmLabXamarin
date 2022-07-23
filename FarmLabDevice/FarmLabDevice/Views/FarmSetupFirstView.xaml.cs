using System;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmLabDevice.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	[SuppressMessage("ReSharper", "PossibleNullReferenceException")]
	public partial class FarmSetupFirstView : ContentPage
	{
		public FarmSetupFirstView()
		{
			InitializeComponent ();
		}

	    private void OnTapGestureCreateFarm(object sender, EventArgs e)
	    {
	        //var bindingContext = BindingContext as FarmSetupFirstViewModel;

	        //await bindingContext.ExecuteButtonCreateFarm();
	    }
	}
}