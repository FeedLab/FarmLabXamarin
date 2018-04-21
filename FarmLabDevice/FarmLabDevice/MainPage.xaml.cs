using System;
using System.Threading.Tasks;
using FarmLabDevice.Managers;
using Xamarin.Forms;

namespace FarmLabDevice
{
	public partial class MainPage : ContentPage
	{
	    readonly FarmLabManager _manager = new FarmLabManager();

        public MainPage()
		{
			InitializeComponent();
		}

	    private void Button_OnClicked(object sender, EventArgs e)
	    {
	        var userInfos = _manager.GetUserInfoItemsAsync(false).Result;
	    }
    }
}
