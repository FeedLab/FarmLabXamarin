using System;
using FarmLabDevice.Dto;
using FarmLabDevice.Helpers;
using FarmLabDevice.Model;
using Newtonsoft.Json;
using RestSharp;

namespace FarmLabDevice.Services
{
    public class AuthProxy
    {
        private readonly Jwt _jwt;

        public AuthProxy(Jwt jwt)
        {
            _jwt = jwt;
        }

        public Jwt RegisterOrLogin(string eMail, string password)
        {
            var host = new Uri(Constants.Host);
            var loginDto = new LoginDto { Email = eMail, Password = password, ConfirmPassword = password, DisplayName ="Change Me" };

            var client = new RestClient(host);

            var request = new RestRequest("Account/RegisterOrLogin", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddHeader("Content-Type", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json", JsonConvert.SerializeObject(loginDto), ParameterType.RequestBody);
            var response = client.Execute<Jwt>(request);

            _jwt.Id = response.Data.Id;
            _jwt.Token = response.Data.Token;
            _jwt.ExpiresInSeconds = response.Data.ExpiresInSeconds;

            return _jwt;
        }

        public Jwt LoginxFarms(string eMail, string password)
        {
            var host = new Uri(Constants.Host);
            var loginDto = new LoginDto { Email = eMail, Password = password, ConfirmPassword = password };

            var client = new RestClient(host);

            var request = new RestRequest("Auth/Token", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddHeader("Content-Type", "application/json");
            //     request.AddHeader("Authorization", "Bearer " + accessToken);
            request.Parameters.Clear();
            request.AddParameter("application/json", JsonConvert.SerializeObject(loginDto), ParameterType.RequestBody);
            var response = client.Execute<Jwt>(request);

            _jwt.Id = response.Data.Id;
            _jwt.Token = response.Data.Token;
            _jwt.ExpiresInSeconds = response.Data.ExpiresInSeconds;

            return _jwt;
        }
    }
}
