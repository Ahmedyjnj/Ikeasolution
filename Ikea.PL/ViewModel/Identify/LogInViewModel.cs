using System.ComponentModel.DataAnnotations;

namespace Ikea.PL.ViewModel.Identify
{
    public class LogInViewModel
    {

        [EmailAddress]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; } 



    }
}
