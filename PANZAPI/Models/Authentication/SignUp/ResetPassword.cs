using System.ComponentModel.DataAnnotations;

namespace PANZAPI.Models.Authentication.SignUp
{
    public class ResetPassword
    {
        [Required]
        public string Password { get; set; } = null;

        [Compare("Password", ErrorMessage = "The passwords do not match.")]

        public string ConfirmPassword { get; set; } = null;

        public string Email { get; set; }

        public string Token { get; set; }
    }
}
