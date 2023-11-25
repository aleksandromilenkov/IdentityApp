using System.ComponentModel.DataAnnotations;

namespace IdentetyPackageProject.ViewModels {
    public class RegisterViewModel {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password dont match")]
        public string ConfirmPassword { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
