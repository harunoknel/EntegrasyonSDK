using System;
using System.Collections.Generic;
namespace PazaryeriEntegrasyon.DTO.TrendYol
{
      public class TrendYolSupplierAdress{
        public List<SupplierAddress> supplierAddresses { get; set; } 
        public DefaultShipmentAddress defaultShipmentAddress { get; set; } 
        public DefaultInvoiceAddress defaultInvoiceAddress { get; set; } 
        public DefaultReturningAddress defaultReturningAddress { get; set; } 
    }
      public class SupplierAddress    {
        public int id { get; set; } 
        public string addressType { get; set; } 
        public string country { get; set; } 
        public string city { get; set; } 
        public int cityCode { get; set; } 
        public string district { get; set; } 
        public int districtId { get; set; } 
        public string postCode { get; set; } 
        public string address { get; set; } 
        public bool returningAddress { get; set; } 
        public string fullAddress { get; set; } 
        public bool shipmentAddress { get; set; } 
        public bool invoiceAddress { get; set; } 
        public bool @default { get; set; } 
    }

    public class DefaultShipmentAddress    {
        public int id { get; set; } 
        public string addressType { get; set; } 
        public string country { get; set; } 
        public string city { get; set; } 
        public int cityCode { get; set; } 
        public string district { get; set; } 
        public int districtId { get; set; } 
        public string postCode { get; set; } 
        public string address { get; set; } 
        public bool returningAddress { get; set; } 
        public string fullAddress { get; set; } 
        public bool shipmentAddress { get; set; } 
        public bool invoiceAddress { get; set; } 
        public bool @default { get; set; } 
    }

    public class DefaultInvoiceAddress    {
        public int id { get; set; } 
        public string addressType { get; set; } 
        public string country { get; set; } 
        public string city { get; set; } 
        public int cityCode { get; set; } 
        public string district { get; set; } 
        public int districtId { get; set; } 
        public string postCode { get; set; } 
        public string address { get; set; } 
        public bool returningAddress { get; set; } 
        public string fullAddress { get; set; } 
        public bool shipmentAddress { get; set; } 
        public bool invoiceAddress { get; set; } 
        public bool @default { get; set; } 
    }

    public class DefaultReturningAddress    {
        public bool present { get; set; } 
    }

}