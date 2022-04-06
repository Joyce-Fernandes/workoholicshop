﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace workoholicshop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int CategoryId { get; set; }
        public string FeaturedPhoto { get; set; }
        public Category Category { get; set; }
        public List <Photo> Photos { get; set; }

        //public static implicit operator Product(Task<ActionResult<IEnumerable<Product>>> v)
        //{
        //    throw new NotImplementedException();
        //}
    }

}
