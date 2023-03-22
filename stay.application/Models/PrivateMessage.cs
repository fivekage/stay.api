namespace stay.application.Models
{
    public class PrivateMessage : Message
    {
        public PrivateMessage(string guid, string message, DateTime writedAt, string writedBy) : base(message, writedAt, writedBy)
        {
            Guid = guid;
        }

        /// <summary>
        /// Me (uuid)
        /// </summary>
        public string Guid { get; set; }
    }
}