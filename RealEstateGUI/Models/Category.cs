﻿using Jedlik.EntityFramework.Helper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class Category
    {
        [Unique]
        public int id { get; set; }
        public string name { get; set; }
    }
}
