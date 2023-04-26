using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Samit_For_Entertainment.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Display(Name = "FullName")]
        public string? FullNmae { get; set; }
    }
}
