namespace stay.application.Requests.DirectLink
{
    public class DirectLinkGetRequest : DirectLinksGetRequest
    {
        /// <summary>
        /// uuid
        /// </summary>
        public string Guid { get; set; }

        public DirectLinkGetRequest(string guid, string me) : base(me)
        {
            Guid = guid;
        }
    }
}