namespace stay.application.Requests.DirectLink
{
    public class DirectLinkGetRequest : DirectLinksGetRequest
    {
        /// <summary>
        /// uuid
        /// </summary>
        public string UserUuid { get; set; }

        public DirectLinkGetRequest(string useruuid, string me) : base(me)
        {
            UserUuid = useruuid;
        }
    }
}