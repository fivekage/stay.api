using System.ComponentModel.DataAnnotations;

namespace stay.application.Requests.User
{
    public class IsLikedGetRequest
    {
        [Required]
        public string UserUid { get; set; }

        [Required]
        public string Me { get; set; }

        public IsLikedGetRequest(string userUid, string me)
        {
            this.UserUid = userUid;
            this.Me = me;
        }
    }
}