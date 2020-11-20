using System;
using System.Collections.Generic;
namespace PazaryeriEntegrasyon
{
    public class CreateAuthorization{
        public string apiKey="";
        public string apiSecret="";
        public string basicAuthorization="";
        public CreateAuthorization(string apikey, string apisecret)
        {
            basicAuthorization = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(apikey + ":" + apisecret));
        }
    }

}