using System.ComponentModel.DataAnnotations;

namespace BlazorEcommerce.Shared
{
    public class UserRegister
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
        ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one digit, one special character, and have a minimum length of 8 characters")]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage ="The passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
