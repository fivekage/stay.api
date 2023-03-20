using System.ComponentModel.DataAnnotations;

namespace stay.application.Requests.DirectLink
{
    public class DirectLinkPostRequest
    {
        public string me { get; set; }
        public string useruuid { get; set; }

        public DirectLinkPostRequest(string me, string useruuid)
        {
            this.me = me ?? throw new ArgumentNullException(nameof(me));
            this.useruuid = useruuid ?? throw new ArgumentNullException(nameof(useruuid));
        }
    }
}