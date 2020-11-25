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
    public class TrendYolCustomerAnswerandQuestion : ControllerBase
    {
        [HttpPost]
        [Route("getTrendyolCustomerQuestions")]
      public TrendyolCustomerQuestions getTrendyolCustomerQuestions(TrendYolAuthorization authorizationItems)
        {
            CreateAuthorization authorization = new CreateAuthorization(authorizationItems.apiKey, authorizationItems.apiSecret);
            var client = new RestClient(string.Format(TrendYolEndPoints.trendyolCustomerQuestionsEndPoint,authorizationItems.SupplierID));
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic "+authorization.basicAuthorization+"");
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            TrendyolCustomerQuestions deserializedTrendTolResponse = JsonConvert.DeserializeObject<TrendyolCustomerQuestions>(response.Content);
            return deserializedTrendTolResponse;
        }    

        [HttpPost]
        [Route("setTrendyolCustomerAnswer")]
    public HttpResponse setTrendyolCustomerAnswer(TrendYolAnswer trendyolAnswer)
        {
            CreateAuthorization authorization = new CreateAuthorization(trendyolAnswer.authorization.apiKey, trendyolAnswer.authorization.apiSecret);
            var client = new RestClient(string.Format(TrendYolEndPoints.trendyolCustomerAnswerEndPoint,trendyolAnswer.authorization.SupplierID,trendyolAnswer.questionID));
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Basic "+authorization.basicAuthorization+"");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(trendyolAnswer.answer), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            HttpResponse deserializedTrendTolResponse = JsonConvert.DeserializeObject<HttpResponse>(response.Content);
            return deserializedTrendTolResponse;
        }   
    }
    }