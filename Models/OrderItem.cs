using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Samit_For_Entertainment.Models
{
    public class OrderItem
    {
        [Key]
        public int ID { get; set; }
        public int Amount { get; set; }
        public double price { get; set; }
        public int MOVIEID { get; set; }
        [ForeignKey("MOVIEID")]
        public MOVIE? MOVIE { get; set; }
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public Order? Oredr { get; set; }
    }
}
