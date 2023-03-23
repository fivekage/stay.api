namespace stay.application.Models
{
    public class Message
    {
        /// <summary>
        /// Message content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Message date creation
        /// </summary>
        public DateTime WritedAt { get; set; }

        /// <summary>
        /// Uid of the user who writed it
        /// </summary>
        public string WritedBy { get; set; }

        public Message( string message, DateTime writedAt, string writedBy)
        {
            Content = message;
            WritedAt = writedAt;
            WritedBy = writedBy;
        }
    }
}