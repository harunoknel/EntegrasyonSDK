using System;
using System.Collections.Generic;
namespace PazaryeriEntegrasyon.ConfigClass
{
 
 // The same type and features were used in order to avoid problems while converting Trendyol product json.
//Capital letters are equalized.
    public static class TrendYolEndPoints{
        public static string trendyolSupplierAddressEnpoint="https://api.trendyol.com/sapigw/suppliers/{0}/addresses";//0-SupplierID
        public static string trendyolShipmentProvidersEnpoint="https://api.trendyol.com/sapigw/shipment-providers";
        public static string trendyolBrandsEnpoint="https://api.trendyol.com/sapigw/brands";
        public static string trendyolCategoryEnpoint="https://api.trendyol.com/sapigw/product-categories";
        public static string trendyolCategoryAttributesEnpoint="https://api.trendyol.com/sapigw/product-categories/{0}/attributes";//0-categoriId
        public static string trendyolProductCreateEndPoint="https://api.trendyol.com/sapigw/suppliers/{0}/v2/products";//0-SupplierID
        public static string trendyolUpdateProductandStockEndpoint="https://api.trendyol.com/sapigw/suppliers/{0}/products/price-and-inventory";//0-SupplierID
        public static string trendyolOrdersEndPoint="https://api.trendyol.com/sapigw/suppliers/{0}/orders";//0-SupplierID
        public static string trendyolCustomerQuestionsEndPoint="https://api.trendyol.com/sapigw//suppliers/{0}/questions/filter";//0-SupplierID
        public static string trendyolCustomerAnswerEndPoint="https://api.trendyol.com/sapigw/suppliers/{0}/questions/{1}/answers";//0-SupplierID 1-QuestionID
    }
}
