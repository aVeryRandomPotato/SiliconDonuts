﻿using System;
namespace SiliconDonuts.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Donut Donut { get; set; }
        public int Amount { get; set; }   
    }
}
