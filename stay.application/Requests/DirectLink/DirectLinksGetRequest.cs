namespace stay.application.Requests.DirectLink
{
    /// <summary>
    /// Get Request
    /// </summary>
    public class DirectLinksGetRequest
    {
        /// <summary>
        /// uuid
        /// </summary>
        public string Me { get; set; }

        public DirectLinksGetRequest(string userUuid)
        {
            Me = userUuid;
        }
    }
}