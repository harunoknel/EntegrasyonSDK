using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using PazaryeriEntegrasyon.DTO.TrendYol;
using PazaryeriEntegrasyon.GenericClasses;
using PazaryeriEntegrasyon.ConfigClass;
using RestSharp;

namespace PazaryeriEntegrasyon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrendyolProductController : ControllerBase
    {
        [HttpPost]
        [Route("getTrendyolSuppliersAddresses")]
        public async Task<TrendYolSupplierAdress> getTrendyolSuppliersAddresses(TrendYolAuthorization authorizationItems)
        {
            CreateAuthorization authorization = new CreateAuthorization(authorizationItems.apiKey, authorizationItems.apiSecret);

            HttpClient trendyolClient = new HttpClient();
            trendyolClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorization.basicAuthorization);
            HttpResponseMessage responseTrendyolSuppliersAddresses = await trendyolClient.GetAsync(string.Format(TrendYolEndPoints.trendyolSupplierAddressEnpoint, authorizationItems.SupplierID));

            var trendyolResponseResult = responseTrendyolSuppliersAddresses.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
            TrendYolSupplierAdress deserializedProduct = JsonConvert.DeserializeObject<TrendYolSupplierAdress>(trendyolResponseResult);
            return deserializedProduct;
        }

        [HttpPost]
        [Route("getTrendYolShipmentProviders")]
        public async Task<List<ShipmentProvider>> getTrendYolShipmentProviders(TrendYolAuthorization authorizationItems)
        {
            CreateAuthorization authorization = new CreateAuthorization(authorizationItems.apiKey, authorizationItems.apiSecret);

            HttpClient trendyolClient = new HttpClient();
            trendyolClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorization.basicAuthorization);
            HttpResponseMessage responseTrendyolShipmentProviders = await trendyolClient.GetAsync(TrendYolEndPoints.trendyolShipmentProvidersEnpoint);

            var trendyolResponseResult = responseTrendyolShipmentProviders.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
            List<ShipmentProvider> deserializedShipmentProvider = JsonConvert.DeserializeObject<List<ShipmentProvider>>(trendyolResponseResult);
            foreach (ShipmentProvider item in deserializedShipmentProvider)
            {
                using (var db = new PazaryeriEntegrasyon.Models.TrendyolDBContext())
                {
                    db.Add(new PazaryeriEntegrasyon.Models.TrendyolShipmentCompany
                    {
                        ShipmentCompanyTrendyolID = item.id,
                        ShipmentCompanyTrendyolCode = item.code,
                        ShipmentCompanyName = item.name,
                        ShipmentCompanyTaxCode = item.taxNumber
                    });
                    db.SaveChanges();
                }
            }
            return deserializedShipmentProvider;
        }

        [HttpPost]
        [Route("getTrendyolBranchs")]
        public async Task<Brands> getTrendyolBranchs(TrendYolAuthorization authorizationItems)
        {
            CreateAuthorization authorization = new CreateAuthorization(authorizationItems.apiKey, authorizationItems.apiSecret);

            HttpClient trendyolClient = new HttpClient();
            trendyolClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorization.basicAuthorization);
            HttpResponseMessage responseTrendyolShipmentProviders = await trendyolClient.GetAsync(TrendYolEndPoints.trendyolBrandsEnpoint);

            var trendyolResponseResult = responseTrendyolShipmentProviders.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
            Brands deserializedBranchs = JsonConvert.DeserializeObject<Brands>(trendyolResponseResult);
            return deserializedBranchs;
        }

        [HttpPost]
        [Route("getTrendyolCategories")]
        public async Task<TrendYolCategory> getTrendyolCategories(TrendYolAuthorization authorizationItems)
        {
            CreateAuthorization authorization = new CreateAuthorization(authorizationItems.apiKey, authorizationItems.apiSecret);

            HttpClient trendyolClient = new HttpClient();
            trendyolClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorization.basicAuthorization);
            HttpResponseMessage responseTrendyolShipmentProviders = await trendyolClient.GetAsync(TrendYolEndPoints.trendyolCategoryEnpoint);

            var trendyolResponseResult = responseTrendyolShipmentProviders.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
            TrendYolCategory deserializedCategory = JsonConvert.DeserializeObject<TrendYolCategory>(trendyolResponseResult);
            foreach (Category category in deserializedCategory.categories)
            {
                if (category.subCategories.Count() == 0)
                {
                    using (var db = new PazaryeriEntegrasyon.Models.TrendyolDBContext())
                    {
                        db.Add(new PazaryeriEntegrasyon.Models.TrendyolCategories
                        {
                            TrendyolCategoryID = category.id,
                            TrendyolCategoryCode = "KGTR",
                            TrendyolCategoryName = category.name,

                        }
                        );
                        db.SaveChanges();
                    }
                }
                else
                {
                    foreach (SubCategory subcategory in category.subCategories)
                    {
                        if (subcategory.subCategories.Count() == 0)
                        {
                            using (var db = new PazaryeriEntegrasyon.Models.TrendyolDBContext())
                            {
                                db.Add(new PazaryeriEntegrasyon.Models.TrendyolCategories
                                {
                                    TrendyolCategoryID = subcategory.id,
                                    TrendyolCategoryCode = "KGTR",
                                    TrendyolCategoryName = subcategory.name,
                                    TrendyolParentCategoryID = subcategory.parentId

                                }
                           );
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            foreach (SubCategory2 subcategory2 in subcategory.subCategories)
                            {
                                if (subcategory2.subCategories.Count() == 0)
                                {
                                    using (var db = new PazaryeriEntegrasyon.Models.TrendyolDBContext())
                                    {
                                        db.Add(new PazaryeriEntegrasyon.Models.TrendyolCategories
                                        {
                                            TrendyolCategoryID = subcategory2.id,
                                            TrendyolCategoryCode = "KGTR",
                                            TrendyolCategoryName = subcategory2.name,
                                            TrendyolParentCategoryID = subcategory2.parentId

                                        }
                                   );
                                        db.SaveChanges();
                                    }
                                }
                                else
                                {
                                    foreach (SubCategory3 subcategory3 in subcategory2.subCategories)
                                    {
                                        if (subcategory3.subCategories.Count() == 0)
                                        {
                                            using (var db = new PazaryeriEntegrasyon.Models.TrendyolDBContext())
                                            {
                                                db.Add(new PazaryeriEntegrasyon.Models.TrendyolCategories
                                                {
                                                    TrendyolCategoryID = subcategory3.id,
                                                    TrendyolCategoryCode = "KGTR",
                                                    TrendyolCategoryName = subcategory3.name,
                                                    TrendyolParentCategoryID = subcategory3.parentId

                                                }
                                           );
                                                db.SaveChanges();
                                            }
                                        }
                                        else
                                        {
                                            foreach (SubCategory4 subcategory4 in subcategory3.subCategories)
                                            {
                                                if (subcategory4.subCategories.Count() == 0)
                                                {
                                                    using (var db = new PazaryeriEntegrasyon.Models.TrendyolDBContext())
                                                    {
                                                        db.Add(new PazaryeriEntegrasyon.Models.TrendyolCategories
                                                        {
                                                            TrendyolCategoryID = subcategory4.id,
                                                            TrendyolCategoryCode = "KGTR",
                                                            TrendyolCategoryName = subcategory4.name,
                                                            TrendyolParentCategoryID = subcategory4.parentId

                                                        }
                                                   );
                                                        db.SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    foreach (SubCategory5 subcategory5 in subcategory4.subCategories)
                                                    {
                                                        if (subcategory5.subCategories.Count() == 0)
                                                        {
                                                            using (var db = new PazaryeriEntegrasyon.Models.TrendyolDBContext())
                                                            {
                                                                db.Add(new PazaryeriEntegrasyon.Models.TrendyolCategories
                                                                {
                                                                    TrendyolCategoryID = subcategory5.id,
                                                                    TrendyolCategoryCode = "KGTR",
                                                                    TrendyolCategoryName = subcategory5.name,
                                                                    TrendyolParentCategoryID = subcategory5.parentId

                                                                }
                                                           );
                                                                db.SaveChanges();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            // 5. katmanlı kategori yapısı olduğu için burayı boş bıraktık
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return deserializedCategory;
        }

        [HttpPost]
        [Route("getTrendyolCategoryAttributes")]
        public async Task<TrendYolCategoryAttributes> getTrendyolCategoryAttributes(TrendYolAuthorization authorizationItems)
        {
            CreateAuthorization authorization = new CreateAuthorization(authorizationItems.apiKey, authorizationItems.apiSecret);

            HttpClient trendyolClient = new HttpClient();

            trendyolClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorization.basicAuthorization);
            HttpResponseMessage responseTrendyolShipmentProviders = await trendyolClient.GetAsync(string.Format(TrendYolEndPoints.trendyolCategoryAttributesEnpoint, 411));

            var trendyolResponseResult = responseTrendyolShipmentProviders.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
            TrendYolCategoryAttributes deserializedCategory = JsonConvert.DeserializeObject<TrendYolCategoryAttributes>(trendyolResponseResult);
            return deserializedCategory;
        }


        [HttpPost]
        [Route("sendTrendyolOneVariantProduct")]
        public TrendYolProductResponse sendTrendyolOneVariantProduct(TrendYolProduct trendyolProductRequest)
        {
            Item trendyolProduct = new Item();
            trendyolProduct.barcode = "111111111";
            trendyolProduct.title = "Deneme Ürünü";
            trendyolProduct.productMainId = "1234BT";
            trendyolProduct.brandId = 1791;
            trendyolProduct.categoryId = 411;
            trendyolProduct.quantity = 1;
            trendyolProduct.stockCode = "DNMURUN";
            trendyolProduct.dimensionalWeight = 1;
            trendyolProduct.description = "Deneme Ürünü";
            trendyolProduct.currencyType = "TRY";
            trendyolProduct.listPrice = 100;
            trendyolProduct.salePrice = 98;
            trendyolProduct.cargoCompanyId = 10;
            Image image = new Image();
            image.url = "https://n11scdn.akamaized.net/a1/org/ev-yasam/biblo/kucuk-urun-fotograf-cekme-oda-studyosu__1205962196402350.jpg";
            trendyolProduct.images = new List<Image>();
            trendyolProduct.images.Add(image);
            trendyolProduct.vatRate = 18;
            DTO.TrendYol.Attribute attribute = new DTO.TrendYol.Attribute();
            attribute.attributeId = 338;
            attribute.attributeValueId = 6980;
            trendyolProduct.attributes = new List<DTO.TrendYol.Attribute>();
            trendyolProduct.attributes.Add(attribute);
            TrendYolProduct product = new TrendYolProduct();
            product.itemList = new DTO.TrendYol.Items();
            product.itemList.items=new List<Item>();
            product.itemList.items.Add(trendyolProduct);

            CreateAuthorization authorization = new CreateAuthorization(trendyolProductRequest.authorization.apiKey, trendyolProductRequest.authorization.apiSecret);
            var client = new RestClient(string.Format(TrendYolEndPoints.trendyolProductCreateEndPoint, trendyolProductRequest.authorization.SupplierID));
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic " + authorization.basicAuthorization);
            request.AddHeader("Content-Type", "application/json");
            string jsondata = JsonConvert.SerializeObject(product.itemList);
            jsondata="{\"items\""+jsondata.ToString()+"}";
            request.AddParameter("application/json", JsonConvert.SerializeObject(product.itemList), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            TrendYolProductResponse deserializedTrendTolResponse = JsonConvert.DeserializeObject<TrendYolProductResponse>(response.Content);
            return deserializedTrendTolResponse;

        }


        ///Çoklu variant olan ürünler için kullanılan metot (X,XL,Kırmızı vb. özellikler için)
        [HttpPost]
        [Route("updateTrendyolProductPriceandStock")]
        public TrendYolProductResponse updateTrendyolProductPriceandStock(TrendYolProductPriceandStock trendyolProductPriceandStockRequest)
        {
            TrendYolProductPriceandStockItem productPriceandStockItem = new TrendYolProductPriceandStockItem();
            productPriceandStockItem.barcode = "111111111";
            productPriceandStockItem.listPrice = 100;
            productPriceandStockItem.salePrice = 90;
            productPriceandStockItem.quantity = 5;
            trendyolProductPriceandStockRequest.items = new List<TrendYolProductPriceandStockItem>();
            trendyolProductPriceandStockRequest.items.Add(productPriceandStockItem);
            CreateAuthorization authorization = new CreateAuthorization(trendyolProductPriceandStockRequest.authorization.apiKey, trendyolProductPriceandStockRequest.authorization.apiSecret);
            var client = new RestClient(string.Format(TrendYolEndPoints.trendyolUpdateProductandStockEndpoint, trendyolProductPriceandStockRequest.authorization.SupplierID));
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic " + authorization.basicAuthorization);
            request.AddHeader("Content-Type", "application/json");
            string jsondata = JsonConvert.SerializeObject(trendyolProductPriceandStockRequest.items);
            request.AddParameter("application/json", JsonConvert.SerializeObject(trendyolProductPriceandStockRequest), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            TrendYolProductResponse deserializedTrendYolResponse = JsonConvert.DeserializeObject<TrendYolProductResponse>(response.Content);
            return deserializedTrendYolResponse;
        }

        // // Birden fazla deposu olan satıcılar için ürün gönderimi yapan servis
        // [HttpPost]
        // [Route("sendTrendyolMultiVariantProduct")]
        // public TrendYolProductStruct sendTrendyolMultiStoreProduct(TrendYolProductStruct trendyolProduct)
        // {

        //     return (new TrendYolProductStruct
        //     {

        //     });

        // }

        // // Ürün güncelleme servisi
        // [HttpPost]
        // [Route("updateTrendyolProduct")]
        // public TrendYolProductStruct updateTrendyolProduct(TrendYolProductStruct trendyolProduct)
        // {

        //     return (new TrendYolProductStruct
        //     {

        //     });

        // }

    }


}
