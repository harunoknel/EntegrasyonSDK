using System;
using System.Collections.Generic;
namespace PazaryeriEntegrasyon.DTO.TrendYol
{
    public class TrendYolProductPriceandStockItem    {
        public string barcode { get; set; } 
        public int quantity { get; set; } 
        public double salePrice { get; set; } 
        public double listPrice { get; set; } 
    }

    public class TrendYolProductPriceandStock    {
        public List<TrendYolProductPriceandStockItem> items { get; set; }
        public TrendYolAuthorization authorization{get;set;}
    }
}