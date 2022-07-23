using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Microsoft.WindowsAzure.MobileServices;

namespace FarmLabDevice.UWP
{
    public sealed partial class MainPage : IAuthenticate
    {
        internal MobileServiceUser _user;

        public MainPage()
        {
            this.InitializeComponent();

     //       FarmLabDevice.App.Init(this);

            LoadApplication(new FarmLabDevice.App());
        }

        public async Task<bool> Authenticate()
        {
            string message = string.Empty;
            var success = false;

            try
            {
                //// Sign in with Facebook login using a server-managed flow.
                //if (_user == null)
                //{
                //    var defaultManagerCurrentClient = FarmLabManager.DefaultManager.CurrentClient;
                //    var provider = MobileServiceAuthenticationProvider.Google;

                //    //HttpBaseProtocolFilter baseFilter = new HttpBaseProtocolFilter();
                //    //foreach (var cookie in baseFilter.CookieManager.GetCookies(new Uri("https://FarmLab.azurewebsites.net")))
                //    //{
                //    //    baseFilter.CookieManager.DeleteCookie(cookie);
                //    //}

                //    //     _user = await defaultManagerCurrentClient.LoginAsync(provider, "localhost:52344); ///.auth/login/google");
                //    await defaultManagerCurrentClient.LogoutAsync();
                //    _user = await defaultManagerCurrentClient.LoginAsync(provider, "farmlab");


                //    if (_user != null)
                //    {
                //        success = true;
                //        message = string.Format("You are now signed-in as {0}.", _user.UserId);
                //    }
                //}

            }
            catch (Exception ex)
            {
                message = string.Format("Authentication Failed: {0}", ex.Message);
            }

            // Display the success or failure message.
            await new MessageDialog(message, "Sign-in result").ShowAsync();

            return success;
        }
    }
}
