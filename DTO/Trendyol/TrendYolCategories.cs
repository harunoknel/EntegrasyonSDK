    using System;
using System.Collections.Generic;
namespace PazaryeriEntegrasyon
{
    public class SubCategory5    {
        public int id { get; set; } 
        public string name { get; set; } 
        public int parentId { get; set; } 
        public List<object> subCategories { get; set; } 
    }

    public class SubCategory4    {
        public int id { get; set; } 
        public string name { get; set; } 
        public int parentId { get; set; } 
        public List<SubCategory5> subCategories { get; set; } 
    }

    public class SubCategory3    {
        public int id { get; set; } 
        public string name { get; set; } 
        public int parentId { get; set; } 
        public List<SubCategory4> subCategories { get; set; } 
    }

    public class SubCategory2    {
        public int id { get; set; } 
        public string name { get; set; } 
        public int parentId { get; set; } 
        public List<SubCategory3> subCategories { get; set; } 
    }

    public class SubCategory    {
        public int id { get; set; } 
        public string name { get; set; } 
        public int parentId { get; set; } 
        public List<SubCategory2> subCategories { get; set; } 
    }

    public class Category    {
        public int id { get; set; } 
        public string name { get; set; } 
        public List<SubCategory> subCategories { get; set; } 
    }

    public class TrendYolCategory    {
        public List<Category> categories { get; set; } 
    }
}