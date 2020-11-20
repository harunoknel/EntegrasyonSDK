using System;
using System.Collections.Generic;
namespace PazaryeriEntegrasyon
{
 
 // The same type and features were used in order to avoid problems while converting Trendyol product json.
//Capital letters are equalized.
    public static class TrendyolEndPoints{
        public static string trendyolSupplierAddressEnpoint="https://api.trendyol.com/sapigw/suppliers/{0}/addresses";
        public static string trendyolShipmentProvidersEnpoint="https://api.trendyol.com/sapigw/shipment-providers";
        public static string trendyolBrandsEnpoint="https://api.trendyol.com/sapigw/brands";
        public static string trendyolCategoryEnpoint="https://api.trendyol.com/sapigw/product-categories";
    }
}
