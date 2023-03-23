using System.ComponentModel.DataAnnotations;

namespace stay.api.Models
{
    /// <summary>
    /// User body request
    /// </summary>
    public class UserBodyRequest
    {
        [Required]
        public string Uid { get; set; } = string.Empty;

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;
     
        public string AvatarURL { get; set; } = string.Empty;
    }
}