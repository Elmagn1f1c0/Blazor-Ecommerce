using System.ComponentModel.DataAnnotations;

namespace BlazorEcommerce.Shared
{
    public class UserChangePassword
    {
        [Required, RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
