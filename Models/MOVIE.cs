using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Samit_For_Entertainment.Data.enums;

namespace Samit_For_Entertainment.Models
{
    public class MOVIE
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        //Relation
        public List<ACTOR_MOVIE> ACTORS_MOVIES { get; set; }
        //Cinama
        public int CINAMAID { get; set; }
        [ForeignKey("CINAMAID")]
        public CINAMA CINAMA { get; set; }
        //PRODUCER
        public int PRODUCERID { get; set; }
        [ForeignKey("PRODUCERID")]
        public PRODUCER PRODUCER { get; set; }
    }
}
