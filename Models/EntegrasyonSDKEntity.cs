using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PazaryeriEntegrasyon.Models
{
    public class TrendyolDBContext : DbContext
    {
        public DbSet<TrendyolCustomers> TrendyolCustomers { get; set; }
        public DbSet<TrendyolShipmentCompany> TrendyolShipmentCompany { get; set; }
        public DbSet<TrendyolCategories> TrendyolCategories { get; set; }
        public DbSet<TrendyolOrders> TrendyolOrders{get;set;}
        public DbSet<TrendYolOrderDetails> TrendYolOrderDetails{get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost;Database=EntegrasyonSDK;User Id=sa;Password=357951Har;");
    }


    public class TrendyolShipmentCompany
    {
        [Key]
        public int ShipmentCompanyID { get; set; }
        [Required]
        public int ShipmentCompanyTrendyolID { get; set; }
        [Required]
        public string ShipmentCompanyTrendyolCode { get; set; }

        [Required]
        public string ShipmentCompanyName { get; set; }
        [Required]
        public string ShipmentCompanyTaxCode { get; set; }

    }

    public class TrendyolCategories
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public int TrendyolCategoryID { get; set; }

        [Required]
        public string TrendyolCategoryCode { get; set; }

        [Required]
        public string TrendyolCategoryName { get; set; }

        [Required]
        public int TrendyolParentCategoryID { get; set; }
    }

    public class TrendyolCustomers
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        public int CustomerTrendYolID { get; set; }
        [Required]
        public string CustomerTCKN { get; set; }

        [Required]
        public string CustomerEmail{get;set;}
        [Required]
        public string CustomerFirstName { get; set; }
        [Required]
        public string CustomerLastName { get; set; }
        [Required]
        public string CustomerShipmentPackageID { get; set; }
        [Required]
        public string CargoTrackingNumber { get; set; }
        [Required]
        public string CargoTrackingLink { get; set; }
        [Required]
        public string CargoSenderNumber { get; set; }
        [Required]
        public string CargoProviderName { get; set; }
    }
    public class TrendyolOrders{
    [Key]
    public int OrderID {get;set;}
    public string OrderCustomerName {get;set;}
    public string OrderAdress {get;set;}
    public string OrderCity {get;set;}
    public string OrderDistrict {get;set;}
    public string OrderInvoiceAdress {get;set;}
    public string OrderInvoiceCustomerName {get;set;}
    public int OrderInvoiceID {get;set;}
    public double OrderGrossAmount {get;set;}
    public double OrderTotalDiscount {get;set;}
    public double OrderTotalPrice {get;set;}
    }

    public class TrendYolOrderDetails{
    [Key]
    public int OrderDetailID {get;set;}
    public int OrderID {get;set;}
    public int OrderDetailQuantity {get;set;}
    public string OrderDetailProductName {get;set;}
    }
}