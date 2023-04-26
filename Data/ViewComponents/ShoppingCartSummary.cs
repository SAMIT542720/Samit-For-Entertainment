using Microsoft.AspNetCore.Mvc;
using Samit_For_Entertainment.Data.Cart;

namespace Samit_For_Entertainment.Data.ViewComponents
{
    public class ShoppingCartSummary : ViewComponent
    {

        private readonly ShoppingCart _shoppingcart;
        public ShoppingCartSummary(ShoppingCart shoppingcart)
        {
            _shoppingcart = shoppingcart;
        }
        public IViewComponentResult Invoke()
        {
            var items = _shoppingcart.GetShoppingCartItems();
            return View(items.Count);
        }
    }
}
