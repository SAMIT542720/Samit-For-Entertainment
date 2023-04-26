
using Samit_For_Entertainment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samit_For_Entertainment.Data.SERVICES
{
    public interface IOredersSERVICE
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string UserID, string UserEmail);
        Task<List<Order>> GetOrdersByUserIDAsync(string UserID);
    }

}
