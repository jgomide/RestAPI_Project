using Cosmonaut.Attributes;
using Newtonsoft.Json;

namespace RestAPI_Project.Domain
{
    [CosmosCollection("posts")]
    public class CosmosPostDto
    {
        [CosmosPartitionKey]
        [JsonProperty("id")]
        public string  Id { get; set; }
        public string Name { get; set; }
    }
}
