using System;
using System.Collections.Generic;
using System.Linq;
using FarmLabDevice.Model;
using RestSharp;

namespace FarmLabDevice.Services
{
    public class AccountProxy : BaseProxy
    {
        private readonly UserInfo _userInfo;

        public AccountProxy(Jwt jwt, UserInfo userInfo)
            : base(jwt)
        {
            _userInfo = userInfo ?? throw new ArgumentNullException(nameof(userInfo));
        }

        public UserInfo GetUserInfo()
        {
            var client = GetHttpClient(true);

            var request = new RestRequest("account/UserInformation", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddHeader("Content-Type", "application/json");
            request.Parameters.Clear();
            var response = client.Execute<UserInfo>(request);

            if(response.Data != null)
                _userInfo.CopyFrom(response.Data);

            return _userInfo;
        }

        public IEnumerable<UserInfo> GetUserInfosForFarm()
        {
            var client = GetHttpClient(true);

            var request = new RestRequest("account/UserInformations", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddHeader("Content-Type", "application/json");
            request.Parameters.Clear();
            var response = client.Execute<List<UserInfo>>(request);

            return response.Data?.Select(CreateUserInfo);
        }

        private static UserInfo CreateUserInfo(UserInfo s)
        {
            var foo = new UserInfo();
            foo.CopyFrom(s);
            return foo;
        }
    }
}
