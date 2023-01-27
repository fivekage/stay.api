using System.Drawing;

namespace stay.application.Requests.ChatRoom
{
    public class ChatRoomPostRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public double Radius { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string CircleColor { get; set; }
        public bool Active { get; set; }

        public ChatRoomPostRequest( string name, string description, string createdBy, bool active, double longitude, double latitude, double radius, string color)
        {
            Name = name;
            Description = description;
            Active = active;
            CreatedBy = createdBy;
            Longitude = longitude;
            Latitude = latitude;
            Radius = radius;
            CircleColor = color;
        }
    }
}