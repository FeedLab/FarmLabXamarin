using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using FarmLabDevice.Model;
using Microsoft.WindowsAzure.MobileServices;

namespace FarmLabDevice.Managers
{
    public class FarmLabManager
    {
//         public static string ApplicationUrl = @"https://FarmLab.azurewebsites.net";
       public static string ApplicationUrl = @"http://localhost:52344";

        private readonly IMobileServiceTable<UserInfo> _userInfoTable;
        private readonly MobileServiceClient _currentClient;

        public FarmLabManager()
        {
            _currentClient = new MobileServiceClient(ApplicationUrl);
            _userInfoTable = _currentClient.GetTable<UserInfo>();
        }

        public static FarmLabManager DefaultManager { get; } = new FarmLabManager();

        public MobileServiceClient CurrentClient => _currentClient;

        public async Task<ObservableCollection<UserInfo>> GetUserInfoItemsAsync(bool syncItems = false)
        {
            try
            {
                var authenticate = await App.Authenticator.Authenticate();

             //   var result = await CurrentClient.InvokeApiAsync("api/values", System.Net.Http.HttpMethod.Get, null);

             //   var items = await _userInfoTable
                    //   .Where(item => !item.Done)
              //      .ToEnumerableAsync();

                return new ObservableCollection<UserInfo>(new List<UserInfo>());
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }

        public async Task SaveTaskAsync(UserInfo item)
        {
            if (item.UserIdentifier == null)
            {
                await _userInfoTable.InsertAsync(item);
            }
            else
            {
                await _userInfoTable.UpdateAsync(item);
            }
        }
    }
}
