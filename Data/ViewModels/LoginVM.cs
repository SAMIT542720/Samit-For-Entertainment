using System.ComponentModel.DataAnnotations;

namespace Samit_For_Entertainment.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="Email Address")]
        [Required(ErrorMessage ="Email address is required")]
        public string? EmialAddress { get; set; }
        [Required]
        [DataType(DataType.Password)] 
        public string? Password { get; set; }
    }
}
