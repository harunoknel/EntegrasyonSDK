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
    public class TrendyolOrdersController : ControllerBase
    {
        [HttpPost]
        [Route("getTrendyolOrders")]
        public TrendYolOrders getTrendyolOrders(TrendYolAuthorization authorizationItems)
        {
            CreateAuthorization authorization = new CreateAuthorization(authorizationItems.apiKey, authorizationItems.apiSecret);
            var client = new RestClient(string.Format(TrendYolEndPoints.trendyolOrdersEndPoint, authorizationItems.SupplierID));
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic " + authorization.basicAuthorization + "");
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            TrendYolOrders deserializedTrendTolResponse = JsonConvert.DeserializeObject<TrendYolOrders>(response.Content);
            foreach (Content content in deserializedTrendTolResponse.content)
            {
                using (var db = new PazaryeriEntegrasyon.Models.TrendyolDBContext())
                {
                    db.Add(new PazaryeriEntegrasyon.Models.TrendyolCustomers
                    {
                        CustomerTrendYolID=content.customerId,
                        CustomerTCKN=content.tcIdentityNumber,
                        CustomerFirstName=content.customerFirstName,
                        CustomerLastName=content.customerLastName,
                        CustomerShipmentPackageID=content.id.ToString(),
                        CargoTrackingNumber=content.cargoTrackingNumber.ToString(),
                        CargoTrackingLink=content.cargoTrackingLink,
                        CargoSenderNumber=content.cargoSenderNumber,
                        CargoProviderName=content.cargoProviderName,
                        CustomerEmail=content.customerEmail

                    }
                    );
                    db.SaveChanges();
                    db.Add(new PazaryeriEntegrasyon.Models.TrendyolOrders{
                        OrderCustomerName=content.shipmentAddress.fullName,
                        OrderAdress=content.shipmentAddress.fullAddress,
                        OrderCity=content.shipmentAddress.city,
                        OrderDistrict=content.shipmentAddress.district,
                        OrderInvoiceID=content.invoiceAddress.id,
                        OrderInvoiceAdress=content.invoiceAddress.fullAddress,
                        OrderInvoiceCustomerName=content.invoiceAddress.fullName,
                        OrderGrossAmount=content.grossAmount,
                        OrderTotalDiscount=content.totalDiscount,
                        OrderTotalPrice=content.totalPrice
                    });
                    int orderid=db.SaveChanges();
                    foreach (Line orderproducts in content.lines)
                    {
                        db.Add(new PazaryeriEntegrasyon.Models.TrendYolOrderDetails{
                            OrderID=orderid,
                            OrderDetailQuantity=orderproducts.quantity,
                            OrderDetailProductName=orderproducts.productName
                        });
                    }
                    db.SaveChanges();
                }
            }
            return deserializedTrendTolResponse;
        }
    }
}