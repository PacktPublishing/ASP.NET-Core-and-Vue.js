using System.ComponentModel.DataAnnotations;

namespace Travel.Application.Dtos.User
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}