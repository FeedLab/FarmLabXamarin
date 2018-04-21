

//[assembly: Dependency(typeof(Authentication))]

namespace FarmLabDevice.iOS
{
    //public class Authentication : IAuthentication
    //{
    //    public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
    //    {
    //        try
    //        {
    //            //attempt to find root view controller to present authentication page
    //            var window = UIKit.UIApplication.SharedApplication.KeyWindow;
    //            var root = window.RootViewController;
    //            if (root != null)
    //            {
    //                var current = root;
    //                while (current.PresentedViewController != null)
    //                {
    //                    current = current.PresentedViewController;
    //                }

    //                //login and save user status
    //                var user = await client.LoginAsync(current, provider);
    //                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
    //                Settings.UserId = user?.UserId ?? string.Empty;

    //                return user;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            e.Data["method"] = "LoginAsync";
    //            Xamarin.Insights.Report(e);
    //        }

    //        return null;
    //    }
    //}
}
