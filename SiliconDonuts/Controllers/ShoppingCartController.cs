using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SiliconDonuts.Models;
using SiliconDonuts.ViewModels;

namespace SiliconDonuts.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IDonutRepository _donutRepository;

        public ShoppingCartController(ShoppingCart shoppingCart, IDonutRepository donutRepository)
        {
            _shoppingCart = shoppingCart;
            _donutRepository = donutRepository;
        }

        public IActionResult Index()
        {
            var cartviewmodel = new CartViewModel();
            cartviewmodel.shoppingCartItems = _shoppingCart.GetCartItems();
            cartviewmodel.totalPrice = _shoppingCart.GetTotalPrice();

            return View(cartviewmodel);
        }

        public RedirectToActionResult AddToCart(int donutId)
        {
            var selectedDonut = _donutRepository.AllDonuts.FirstOrDefault(d => d.DonutId == donutId);

            if (selectedDonut != null)
            {
                _shoppingCart.AddToShoppingCart(selectedDonut, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCart(int donutId)
        {
            var selectedDonut = _donutRepository.AllDonuts.FirstOrDefault(d => d.DonutId == donutId);

            if (selectedDonut != null)
            {
                _shoppingCart.RemoveFromShoppingCart(selectedDonut, 1);

            }


            return RedirectToAction("Index");
        }

        public RedirectToActionResult DeleteFromCart(int donutId)
        {
            var selectedDonut = _donutRepository.AllDonuts.FirstOrDefault(d => d.DonutId == donutId);

            if (selectedDonut != null)
            {
                _shoppingCart.RemoveFromShoppingCart(selectedDonut, 0);

            }

            return RedirectToAction("Index");
        }

    }
}
