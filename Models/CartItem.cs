﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLowerShop.Models
{
    public class CartItem
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total => Price * Quantity;
    }
}