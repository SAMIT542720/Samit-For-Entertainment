using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Samit_For_Entertainment.Models
{
    public class CINAMA
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Cinema Logo")]
        public string? Logo { get; set; }
        [Display(Name = "Cinema Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = ("Full Name  must be between 3 and 50 chars"))]
        public string? Name { get; set; }
        [Display(Name = "Cinema Description")]
        public string? Description { get; set; }
        //Relations
        public List<MOVIE>? MOVIES { get; set; }

    }
}
