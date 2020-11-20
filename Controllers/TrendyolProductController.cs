using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace PazaryeriEntegrasyon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrendyolProductController : ControllerBase
    {
        [HttpPost]
        [Route("getTrendyolSuppliersAddresses")]
        public async Task<TrendyolSupplierAdress> getTrendyolSuppliersAddresses(TrendYolAuthorization authorizationItems)
        {
            CreateAuthorization authorization=new CreateAuthorization(authorizationItems.apiKey,authorizationItems.apiSecret); 

            HttpClient trendyolClient = new HttpClient();
            trendyolClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorization.basicAuthorization);
            HttpResponseMessage responseTrendyolSuppliersAddresses =await trendyolClient.GetAsync(string.Format(TrendyolEndPoints.trendyolSupplierAddressEnpoint,authorizationItems.SupplierID));

            var trendyolResponseResult = responseTrendyolSuppliersAddresses.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
            TrendyolSupplierAdress deserializedProduct = JsonConvert.DeserializeObject<TrendyolSupplierAdress>(trendyolResponseResult);
            return deserializedProduct;
        }

        [HttpPost]
        [Route("sendProduct")]
        public Item sendTrendyolProduct(Item trendyolProduct)
        {
           
            return (new Item
            {
                
            });
            
        }
        
    }
}
