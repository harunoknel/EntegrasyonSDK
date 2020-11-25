    using System;
using System.Collections.Generic;
namespace PazaryeriEntegrasyon.DTO.TrendYol
{
    public class Brand    {
        public int id { get; set; } 
        public string name { get; set; } 
    }
     public class Brands {
        public List<Brand> brands { get; set; } 
    }
}