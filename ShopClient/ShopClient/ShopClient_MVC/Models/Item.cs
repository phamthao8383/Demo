﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopClient_MVC.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int AvailbleAmount { get; set; }
        public int SaleAmount { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; } // real price = price - Discount*price/100
        public byte[] ImagePath { get; set; }
    }
}