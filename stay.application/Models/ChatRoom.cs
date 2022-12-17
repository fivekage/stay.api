namespace stay.application.Models
{
    public class ChatRoom
    {
        public string Uuid { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public ChatRoom(string uuid,
            string createdBy,
            string createdAt,
            double longitude,
            double latitude
            )
        {
            Uuid = uuid;
            CreatedBy = createdBy;
            CreatedAt = createdAt;
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}