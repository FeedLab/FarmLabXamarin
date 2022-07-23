using System.Collections.Generic;
using System.Threading.Tasks;
using FarmLabDevice.Model;
using Newtonsoft.Json;
using RestSharp;

namespace FarmLabDevice.Services
{
    public class FarmProxy : BaseProxy
    {
        public FarmProxy(Jwt jwt)
        : base(jwt)
        {
        }

        public IEnumerable<FarmItem> Farms()
        {
            var client = GetHttpClient(true);

            var request = new RestRequest("farm", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddHeader("Content-Type", "application/json");
            request.Parameters.Clear();
            var response = client.Execute<List<FarmItem>>(request);

            return response.Data;
        }

        public Task<FarmItem> CreateFarm(CreateFarmModel model)
        {
            var client = GetHttpClient(true);

            var request = new RestRequest("farm", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddHeader("Content-Type", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json", JsonConvert.SerializeObject(model), ParameterType.RequestBody);

            var response = client.Execute<FarmItem>(request);

            return Task.FromResult(response.Data);
        }
    }
}
