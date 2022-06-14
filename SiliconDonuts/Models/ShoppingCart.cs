using System;
using System.Collections.Generic;
using System.Linq;

namespace SiliconDonuts.Models
{
    public class ShoppingCart
    { 
        public int ShoppingCartId { get; set; }
        public List<ShoppingCartItem> shoppingCartItems { get; set; }

        private readonly ApplicationDbContext _db;

        public ShoppingCart(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddToShoppingCart(ShoppingCartItem item, int amount)
        {
            var checkItem = _db.ShoppingCartItems.SingleOrDefault(i => i.Donut.DonutId == item.Donut.DonutId);

            if (checkItem != null)
            {
                checkItem = new ShoppingCartItem
                {
                    ShoppingCartItemId = item.ShoppingCartItemId,
                    Donut = item.Donut,
                    Amount = amount
                };
            }
            else
            {
                checkItem.Amount++;
            }
        }
    }
}
