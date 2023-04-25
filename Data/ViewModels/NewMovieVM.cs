using Samit_For_Entertainment.Data.enums;
using System.ComponentModel.DataAnnotations;

namespace Samit_For_Entertainment.Data.ViewModels
{
    public class NewMovieVM
    {
        public int ID { get; set; }
        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name is Required")]
        public string? Name { get; set; }
        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is Required")]
        public string? Description { get; set; }
        [Display(Name = "Movie Price in $")]
        [Required(ErrorMessage = "Price is Required")]
        public double Price { get; set; }
        [Display(Name = "Movie Image URL")]
        [Required(ErrorMessage = "Image URL is Required")]
        public string? ImageURL { get; set; }
        [Display(Name = "Movie Start date")]
        [Required(ErrorMessage = "Start date is Required")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Movie End date")]
        [Required(ErrorMessage = "End date  is Required")]
        public DateTime EndDate { get; set; }
        [Display(Name = " Select Movie category")]
        [Required(ErrorMessage = "Movie category is Required")]
        public MovieCategory MovieCategory { get; set; }
        [Display(Name = "Select one or more Movie Actors")]
        [Required(ErrorMessage = "Movie Actors are  Required")]
        public List<int> ACTORIDS { get; set; }
        [Display(Name = "Select Cinema")]
        [Required(ErrorMessage = "Movie Cinema is Required")]
        public int CINAMAID { get; set; }
        [Display(Name = "Select Producer")]
        [Required(ErrorMessage = "Movie producer is Required")]
        public int PRODUCERID { get; set; }

    }
}
