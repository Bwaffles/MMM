using System.ComponentModel.DataAnnotations;

namespace Application.Users.Commands.SignIn
{
    public class SignInModel
    {
        [Required]
        [Display(Name = "Username or Email")]
        public string LoginId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }
}