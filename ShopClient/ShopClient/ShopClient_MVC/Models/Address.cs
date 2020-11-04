﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopClient_MVC.Models
{
    public class Province
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class District
    {
        public int ID { get; set; }
        public int IDProvince { get; set; }
        public string Name { get; set; }
    }
    public class Commune
    {
        public int ID { get; set; }
        public int IDDistrict { get; set; }
        public string Name { get; set; }
    }

}