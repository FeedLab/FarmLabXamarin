using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using FarmLabDevice;
using FarmLabDevice.Managers;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace FarmLab.Droid
{
    [Activity(Label = "FarmLab", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IAuthenticate
    {
        // Define a authenticated user.
        private MobileServiceUser _user;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Initialize Azure Mobile Apps
            CurrentPlatform.Init();

            // Initialize Xamarin Forms
            Forms.Init(this, bundle);


            // Initialize the authenticator before loading the app.
            App.Init(this);

            // Load the main application
            LoadApplication(new App());
        }

        public async Task<bool> Authenticate()
        {
            var success = false;
            var message = string.Empty;
            try
            {
                var defaultManagerCurrentClient = FarmLabManager.DefaultManager.CurrentClient;
                var provider = MobileServiceAuthenticationProvider.Google;

                // Sign in with Facebook login using a server-managed flow.
                _user = await defaultManagerCurrentClient.LoginAsync(this, provider, "FarmLab");
                if (_user != null)
                {
                    message = $"you are now signed-in as {_user.UserId}.";
                    success = true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            // Display the success or failure message.
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle("Sign-in result");
            builder.Create().Show();

            return success;
        }
    }
}
