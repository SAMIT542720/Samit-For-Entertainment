﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Samit_For_Entertainment.Data.Cart;
using Samit_For_Entertainment.Data.Services;
using Samit_For_Entertainment.Data.SERVICES;
using Samit_For_Entertainment.Data.Static;
using Samit_For_Entertainment.Data.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Samit_For_Entertainment.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IMOVIESSERVICE _mOVIESSERVICE;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOredersSERVICE _oredersSERVICE;
        public OrdersController(IMOVIESSERVICE mOVIESSERVICE, ShoppingCart shoppingCart, IOredersSERVICE oredersSERVICE)
        {
            _mOVIESSERVICE = mOVIESSERVICE;
            _shoppingCart = shoppingCart;
            _oredersSERVICE = oredersSERVICE;
        }
        public async Task<IActionResult> Index()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = await _oredersSERVICE.GetOrdersByUserIDAndRolAsync(userid,userRole);
            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                shoppingCart = _shoppingCart,
                shoppingcarttotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }
        public async Task<IActionResult> AddItemToCart(int id)
        {
            var item = await _mOVIESSERVICE.GetMovieByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<IActionResult> RemoveItemFromShopingCart(int id)
        {
            var item = await _mOVIESSERVICE.GetMovieByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string useremail = User.FindFirstValue(ClaimTypes.Email);
            await _oredersSERVICE.StoreOrderAsync(items, userid, useremail);
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }
    }

}
