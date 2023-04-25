using Samit_For_Entertainment.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Samit_For_Entertainment.Models
{
    public class ACTOR : IEntityBase
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Profile picture")]
        [Required(ErrorMessage = ("Profile Picture is required"))]
        public string? ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = ("Full Name is required"))]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be 3 and 50 chars")]
        public string? FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = ("Biography is required"))]
        public string? Bio { get; set; }
        //Realtion
        public List<ACTOR_MOVIE>? ACTORS_MOVIES { get; set; }
    }
}
