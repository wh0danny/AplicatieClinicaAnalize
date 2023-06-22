using AplicatieClinicaAnalize.Data.Cart;
using AplicatieClinicaAnalize.Data.Services;
using AplicatieClinicaAnalize.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AplicatieClinicaAnalize.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IAnalizeService _analizeService;
        private readonly ShoppingCart _shoppingCart;

        public OrdersController(IAnalizeService analizeService, ShoppingCart shoppingCart)
        {
            _analizeService = analizeService;
            _shoppingCart = shoppingCart;
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public RedirectToActionResult AddItemFromShoppingCart(int id)
        {
            var item = _analizeService.GetById(id);

            if(item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public RedirectToActionResult RemoveItemFromShoppingCart(int id)
        {
            var item = _analizeService.GetById(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
