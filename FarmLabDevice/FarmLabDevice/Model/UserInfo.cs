using System;

namespace FarmLabDevice.Model
{
    public class UserInfo
    {
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("UserIdentifier")]
        public string UserIdentifier { get; set; }

        [Newtonsoft.Json.JsonProperty("FarmId")]
        public Guid FarmId { get; set; }

        [Newtonsoft.Json.JsonProperty("FarmName")]
        public string FarmName { get; set; }

        [Newtonsoft.Json.JsonProperty("FarmCreated")]
        public DateTime FarmCreated { get; set; }
    }
}
