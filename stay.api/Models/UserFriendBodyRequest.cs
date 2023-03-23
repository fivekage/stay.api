using System.ComponentModel.DataAnnotations;

namespace stay.api.Models
{
    public class UserFriendBodyRequest
    {
        [Required]
        public string Me { get; set; } = string.Empty;

        [Required]
        public string FriendUid { get; set; } = string.Empty;
    }
}
