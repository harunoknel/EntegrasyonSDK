using System;
using System.Collections.Generic;
namespace PazaryeriEntegrasyon.DTO.TrendYol
{
    public class ProductImage    {
        public string url { get; set; } 
    }

    public class VariantAttribute    {
        public string attributeName { get; set; } 
        public string attributeValue { get; set; } 
    }

    public class Product    {
        public string brand { get; set; } 
        public string barcode { get; set; } 
        public string title { get; set; } 
        public string description { get; set; } 
        public string categoryName { get; set; } 
        public double listPrice { get; set; } 
        public double salePrice { get; set; } 
        public string currencyType { get; set; } 
        public int vatRate { get; set; } 
        public string cargoCompany { get; set; } 
        public int quantity { get; set; } 
        public string stockCode { get; set; } 
        public List<Image> images { get; set; } 
        public string productMainId { get; set; } 
        public string gender { get; set; } 
        public int dimensionalWeight { get; set; } 
        public List<object> attributes { get; set; } 
        public List<VariantAttribute> variantAttributes { get; set; } 
    }

    public class RequestItem    {
        public Product product { get; set; } 
    }

    public class ProductItem   {
        public RequestItem requestItem { get; set; } 
        public string status { get; set; } 
        public List<object> failureReasons { get; set; } 
    }

    public class TrendYolProductResponse    {
        public string batchRequestId { get; set; } 
        public List<ProductItem> items { get; set; } 
        public string status { get; set; } 
        public long creationDate { get; set; } 
        public long lastModification { get; set; } 
        public string sourceType { get; set; } 
        public int itemCount { get; set; } 
    }
    }

