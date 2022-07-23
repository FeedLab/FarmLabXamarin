using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace FarmLabDevice.Managers
{
    public class FarmLabManager
    {
         public static string ApplicationUrl = @"https://FarmLab.azurewebsites.net";
        public static string ApplicationUrlLocal = @"http://82.183.31.17:5000";

  //      private readonly IMobileServiceTable<UserInfo> _userInfoTable;
        private readonly MobileServiceClient _currentClient;

        public FarmLabManager()
        {
            _currentClient =
                new MobileServiceClient(ApplicationUrlLocal)
                {
                    AlternateLoginHost = new Uri(ApplicationUrl)
                };
        }

        public static FarmLabManager DefaultManager { get; } = new FarmLabManager();

        public MobileServiceClient CurrentClient => _currentClient;

        public async Task<bool> AuthenticateAsync(bool syncItems = false)
        {
            try
            {
                var result = await App.Authenticator.Authenticate();

                IDictionary<string, string> headerDictionary = new Dictionary<string, string>();
                var response = await CurrentClient.InvokeApiAsync("Farm", HttpMethod.Get, null);

                var resultx = await CurrentClient.InvokeApiAsync("api/values", HttpMethod.Get, null);

                return result;


                //   var items = await _userInfoTable
                //   .Where(item => !item.Done)
                //      .ToEnumerableAsync();

            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return false;
        }

        //    public async Task SaveTaskAsync(UserInfo item)
        //    {
        //        if (item.UserIdentifier == null)
        //        {
        //            await _userInfoTable.InsertAsync(item);
        //        }
        //        else
        //        {
        //            await _userInfoTable.UpdateAsync(item);
        //        }
        //    }
        }
    }
