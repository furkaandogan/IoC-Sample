﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Web.UI.Models
{
    public class CarPostModel
    {
        public int CustomerId { get; set; }
        public string Plate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}