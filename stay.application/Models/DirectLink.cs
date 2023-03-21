using Newtonsoft.Json;

namespace stay.application.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DirectLink
    {
        public string Me { get; set; }
        public string UserUuid { get; set; }
        public string Username { get; set; } = string.Empty;

        public DirectLink(string me, string userUuid)
        {
            Me = me;
            UserUuid = userUuid;
        }

        [JsonConstructor]
        public DirectLink(string me, string userUuid, string username)
        {
            Me = me;
            UserUuid = userUuid;
            Username = username;
        }
    }
}