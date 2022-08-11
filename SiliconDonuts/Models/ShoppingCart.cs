using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public void AddToShoppingCart(Donut donut, int amount)
        {
            var checkItem = _db.ShoppingCartItems.SingleOrDefault(i => i.Donut.DonutId == donut.DonutId);

            if (checkItem == null)
            { 
                checkItem = new ShoppingCartItem
                {
                    //ShoppingCartItemId = checkItem.ShoppingCartItemId,
                    Donut = donut,
                    Amount = amount
                };
                _db.ShoppingCartItems.Add(checkItem);
            }
            else
            {
                checkItem.Amount += amount;
            }

            _db.SaveChanges();
        }

        public void RemoveFromShoppingCart(Donut donut, int amount)
        {
            var checkItem = _db.ShoppingCartItems.SingleOrDefault(i => i.Donut.DonutId == donut.DonutId);

            if (checkItem != null)
            {

                if (amount == 0)
                {
                    checkItem.Amount = 0;
                }

                var localAmount = checkItem.Amount - amount;

                if (localAmount > 0)
                {
                    checkItem.Amount = localAmount;
                }
                else
                {
                    _db.ShoppingCartItems.Remove(checkItem);
                    _db.SaveChanges();
                }
                

            }

            _db.SaveChanges();
        }

        public decimal GetTotalPrice()
        {
            var totalList = _db.ShoppingCartItems.Select(i => i.Donut.DonutPrice * i.Amount).ToList();
            decimal total = 0;
            foreach (var item in totalList)
            {
                total += item;
            }

            return total;
        }

        public List<ShoppingCartItem> GetCartItems()
        {
            var items = _db.ShoppingCartItems.Include(d => d.Donut).ToList();

            return items;
        }
    }
}
