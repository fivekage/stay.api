namespace stay.application.Models
{
    public class ChatRoom
    {
        public string Uuid { get; set; }
        public string CreatedBy { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }        
        public IEnumerable<object> Threads { get; set; }


        public ChatRoom(string uuid,
            string createdBy,
            DateTime createdAt,
            bool active,
            double longitude,
            double latitude
            )
        {
            Uuid = uuid;
            Active = active;
            CreatedBy = createdBy;
            CreatedAt = createdAt;
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}