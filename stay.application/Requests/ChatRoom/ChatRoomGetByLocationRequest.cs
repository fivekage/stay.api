using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stay.application.Requests.ChatRoom
{
    public class ChatRoomGetByLocationRequest
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public ChatRoomGetByLocationRequest(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
