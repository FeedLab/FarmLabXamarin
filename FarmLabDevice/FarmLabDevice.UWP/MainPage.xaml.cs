using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using FarmLabDevice.Managers;
using Microsoft.WindowsAzure.MobileServices;

namespace FarmLabDevice.UWP
{
    public sealed partial class MainPage : IAuthenticate
    {
        internal MobileServiceUser _user;

        public MainPage()
        {
            this.InitializeComponent();

            FarmLabDevice.App.Init(this);

            LoadApplication(new FarmLabDevice.App());
        }

        public async Task<bool> Authenticate()
        {
            string message = string.Empty;
            var success = false;

            try
            {
                // Sign in with Facebook login using a server-managed flow.
                if (_user == null)
                {
                    _user = await FarmLabManager.DefaultManager.CurrentClient
                        .LoginAsync(MobileServiceAuthenticationProvider.Google, "https://farmlab.azurewebsites.net/signin-google");
                    if (_user != null)
                    {
                        success = true;
                        message = string.Format("You are now signed-in as {0}.", _user.UserId);
                    }
                }

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
