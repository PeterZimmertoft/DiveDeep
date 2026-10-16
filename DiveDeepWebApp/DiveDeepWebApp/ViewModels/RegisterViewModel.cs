using System.ComponentModel.DataAnnotations;

namespace DiveDeepWebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email er påkrævet.")]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Adgangskode er påkrævet.")]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Adgangskode er påkrævet.")]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = "";
    }
}