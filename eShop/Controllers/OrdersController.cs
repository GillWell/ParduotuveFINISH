using eShop.Data.Cart;
using eShop.Data.Services;
using eShop.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace eShop.Controllers
{
	[Authorize(Roles = "Buyer")]
	public class OrdersController : Controller
	{
		private readonly IMoviesService _moviesService;
		private readonly ShoppingCart _shoppingCart;
		private readonly IOrdersService _ordersService;
		public OrdersController(IMoviesService moviesService, ShoppingCart shoppingCart, IOrdersService ordersService)
		{
			_moviesService = moviesService;
			_shoppingCart = shoppingCart;
			_ordersService = ordersService;
		}
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Index()
		{
			string userId = "";
			var orders = await _ordersService.GetOrdersByUserIdAsync(userId);
			return View(orders);
		}

		public IActionResult ShoppingCart()
		{
			var items = _shoppingCart.GetShoppingCartItems();
			_shoppingCart.ShoppingCartItems = items;
			var response = new ShoppingCartVM()
			{
				ShoppingCart = _shoppingCart,
				ShoppingCartTotal = _shoppingCart.GetShoppingTotal()
			};

			return View(response);
		}

		public async Task<RedirectToActionResult> AddToShoppingCart(int id)
		{
			var item = await _moviesService.GetMovieByIdAsync(id);

			if(item != null)
			{
				_shoppingCart.AddItemToCart(item);
			}
			return RedirectToAction(nameof(ShoppingCart));
		}

        public async Task<RedirectToActionResult> RemoveFromShoppingCart(int id)
        {
            var item = await _moviesService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

		public async Task<IActionResult> CompleteOrder()
		{
			var items = _shoppingCart.GetShoppingCartItems();
			string userId = "";
			string userEmailAddress = "";

			await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
			await _shoppingCart.ClearShoppingCart();
			return View("OrderComplete");
		}

	}
}
