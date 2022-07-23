using System;
using FarmLabDevice.Helpers;
using FarmLabDevice.Model;
using RestSharp;
using RestSharp.Authenticators;

namespace FarmLabDevice.Services
{
    public abstract class BaseProxy
    {
        protected readonly Jwt Jwt;

        protected BaseProxy(Jwt jwt)
        {
            Jwt = jwt;
        }

        protected RestClient GetHttpClient(bool withBearerToken)
        {
            var host = new Uri(Constants.Host);
            var client = new RestClient(host);

            if(withBearerToken)
                client.Authenticator = new JwtAuthenticator(Jwt.Token);

            return client;
        }
    }
}
