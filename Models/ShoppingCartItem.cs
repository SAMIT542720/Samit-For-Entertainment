using System.ComponentModel.DataAnnotations;

namespace Samit_For_Entertainment.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ID { get; set; }
        public MOVIE? movie { get; set; }
        public int Amount { get; set; }
        public string? ShoppingCartID { get; set; }
    }
}
