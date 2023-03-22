using Newtonsoft.Json;

namespace stay.application.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DirectLink
    {
        [JsonProperty(PropertyName = "RoomUID")]
        public string Guid { get; set; }

        [JsonProperty(PropertyName = "Members")]
        public List<string> Members { get; set; }

        public DirectLink(string guid, List<string> members)
        {
            Guid = guid;
            Members = members;
        }
    }
}