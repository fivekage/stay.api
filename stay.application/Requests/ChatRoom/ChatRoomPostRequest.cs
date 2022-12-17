using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stay.application.Requests.ChatRoom
{
    public class ChatRoomPostRequest
    {
        public string Uuid { get; set; }
        public string CreatedBy { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool Active { get; set; }

        public ChatRoomPostRequest(string uuid, string createdBy, bool active, double longitude, double latitude)
        {
            Uuid = uuid;
            Active = active;
            CreatedBy = createdBy;
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
