using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Samit_For_Entertainment.Data;
using Samit_For_Entertainment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samit_For_Entertainment.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext? _context { get; set; }
        public string? ShoppingCartID { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }
        public static ShoppingCart GretSoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string cardid = session.GetString("cardid") ?? Guid.NewGuid().ToString();
            session.SetString("cardid", cardid);
            return new ShoppingCart(context) { ShoppingCartID = cardid };
        }
        public void AddItemToCart(MOVIE Movie)
        {
            var shoppincartitem = _context.shoppingCartItems.FirstOrDefault(n => n.movie.ID == Movie.ID && n.ShoppingCartID == ShoppingCartID);
            if (shoppincartitem == null)
            {
                shoppincartitem = new ShoppingCartItem()
                {
                    ShoppingCartID = ShoppingCartID,
                    movie = Movie,
                    Amount = 1
                };


                _context.shoppingCartItems.Add(shoppincartitem);
            }
            else
            {
                shoppincartitem.Amount++;
            }
            _context.SaveChanges();
        }
        public void RemoveItemFromCart(MOVIE Movie)
        {
            var shoppincartitem = _context.shoppingCartItems.FirstOrDefault(n => n.movie.ID == Movie.ID && n.ShoppingCartID == ShoppingCartID);
            if (shoppincartitem != null)
            {
                if (shoppincartitem.Amount > 1)
                {
                    shoppincartitem.Amount--;
                }
                else
                {
                    _context.shoppingCartItems.Remove(shoppincartitem);
                }
            }
            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {

            return ShoppingCartItems ?? (ShoppingCartItems = _context.shoppingCartItems.Where(n => n.ShoppingCartID == ShoppingCartID).Include(n => n.movie).ToList());
        }
        public double GetShoppingCartTotal()
        {
            var total = _context.shoppingCartItems.Where(n => n.ShoppingCartID == ShoppingCartID).Select(n => n.movie.Price * n.Amount).Sum();
            return total;
        }
        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.shoppingCartItems.Where(n => n.ShoppingCartID == ShoppingCartID).ToListAsync();
            _context.shoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}

