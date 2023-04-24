namespace Samit_For_Entertainment.Models
{
    public class ACTOR_MOVIE
    {
        public int MOVIEID { get; set; }
        public MOVIE? MOVIE { get; set; }
        public int ACTORID { get; set; }
        public ACTOR? ACTOR { get; set; }
    }
}
