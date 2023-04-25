using Samit_For_Entertainment.Models;

namespace Samit_For_Entertainment.Data.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public NewMovieDropdownsVM()
        {
            producers = new List<PRODUCER>();
            cinamas = new List<CINAMA>();
            actors = new List<ACTOR>();
        }
        public List<PRODUCER> producers { get; set; }
        public List<CINAMA> cinamas { get; set; }
        public List<ACTOR> actors { get; set; }
    }
}
