using System.ComponentModel.DataAnnotations;

namespace DiveDeepWebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email er påkrævet.")]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Adgangskode er påkrævet.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
    }

}