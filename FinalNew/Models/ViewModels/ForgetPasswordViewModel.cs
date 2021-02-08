using System.ComponentModel.DataAnnotations;

namespace FinalNew.Models.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
