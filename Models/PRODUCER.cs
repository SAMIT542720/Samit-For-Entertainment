using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Samit_For_Entertainment.Models
{
    public class PRODUCER
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Profile pictur")]
        [Required(ErrorMessage = ("The profile picture is required "))]
        public string? ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = ("Full Nmae is required "))]
        [StringLength(50, MinimumLength = 3, ErrorMessage = ("Full Name must be 3 and 50 chars"))]
        public string? FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = ("Biography  is required "))]
        public string? Bio { get; set; }
        //Relations
        public List<MOVIE>? MOVIES { get; set; }
    }
}
