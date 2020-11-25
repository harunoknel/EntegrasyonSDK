using System;
using System.Collections.Generic;
namespace PazaryeriEntegrasyon.DTO.TrendYol
{
    public class TrendYolAnswer{
        public TrendYolAuthorization authorization{get;set;}
        public int questionID{get;set;}
        public string answer{get;set;}
    }
}