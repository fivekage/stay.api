namespace stay.application.Models
{
    public class PrivateMessage : Message
    {
        public PrivateMessage(string guid, string message, DateTime writedAt, string writedBy, string contentType) : base(message, writedAt, writedBy, contentType)
        {
            Guid = guid;
        }

        /// <summary>
        /// Me (uuid)
        /// </summary>
        public string Guid { get; set; }
    }
}