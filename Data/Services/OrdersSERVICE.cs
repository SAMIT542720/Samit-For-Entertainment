
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Samit_For_Entertainment.Data;
using Samit_For_Entertainment.Models;
using Samit_For_Entertainment.Data.SERVICES;

namespace Samit_For_EntertainmentE.Data.SERVICES
{
    public class OrdersSERVICE : IOredersSERVICE
    {
        private readonly AppDbContext _context;
        public OrdersSERVICE(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersByUserIDAsync(string UserID)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.MOVIE).Where(n => n.UserID == UserID).ToListAsync();
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string UserID, string UserEmail)
        {
            var order = new Order()
            {
                UserID = UserID,
                Email = UserEmail
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            foreach (var item in items)
            {
                var orderitem = new OrderItem()
                {
                    Amount = item.Amount,
                    MOVIEID = item.movie.ID,
                    OrderID = order.ID,
                    price = item.movie.Price
                };
                await _context.OrderItems.AddAsync(orderitem);
            }
            await _context.SaveChangesAsync();

        }
    }
}
