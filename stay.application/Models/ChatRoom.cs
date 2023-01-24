using Newtonsoft.Json;

namespace stay.application.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ChatRoom
    {
        [JsonProperty(PropertyName = "Uuid")]
        public string Uuid { get; set; }
        [JsonProperty(PropertyName = "CreatedBy")]
        public string CreatedBy { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty(PropertyName = "Active")]
        public bool Active { get; set; }
        [JsonProperty(PropertyName = "Longitude")]
        public double Longitude { get; set; }
        [JsonProperty(PropertyName = "Latitude")]
        public double Latitude { get; set; }     
        [JsonProperty(PropertyName = "Threads")]
        public Dictionary<string, object>? Threads { get; set; }

        public ChatRoom(string uuid,
            string createdBy,
            DateTime createdAt,
            bool active,
            double longitude,
            double latitude,
            Dictionary<string, object>? threads = null
            )
        {
            Uuid = uuid;
            Active = active;
            CreatedBy = createdBy;
            CreatedAt = createdAt;
            Longitude = longitude;
            Latitude = latitude;
            Threads = threads;
        }
    }
    public class DataThreads
    {
        public List<int> Test { get; set; }

        public DataThreads(List<int> test)
        {
            Test = test;
        }
    }
}