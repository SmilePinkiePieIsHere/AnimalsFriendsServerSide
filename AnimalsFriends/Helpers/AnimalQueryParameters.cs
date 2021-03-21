using Newtonsoft.Json;

namespace AnimalsFriends.Helpers
{
    public class AnimalQueryParameters : QueryParameters
    {     
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
