namespace stay.application.Models
{
    public class Message
    {
        /// <summary>
        /// Message content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Message content type
        /// </summary>
        public string ContentType { get; set; } = "text";

        /// <summary>
        /// Message date creation
        /// </summary>
        public DateTime WritedAt { get; set; }

        /// <summary>
        /// Uid of the user who writed it
        /// </summary>
        public string WritedBy { get; set; }

        public Message( string message, DateTime writedAt, string writedBy, string contentType)
        {
            Content = message;
            WritedAt = writedAt;
            WritedBy = writedBy;
            ContentType = contentType;
        }
    }
}