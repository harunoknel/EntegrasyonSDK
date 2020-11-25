using System;
using System.Collections.Generic;
namespace PazaryeriEntegrasyon.DTO.TrendYol
{     public class Answer    {
        public int creationDate { get; set; } 
        public bool hasPrivateInfo { get; set; } 
        public int id { get; set; } 
        public string reason { get; set; } 
        public string text { get; set; } 
    }

    public class RejectedAnswer    {
        public int creationDate { get; set; } 
        public int id { get; set; } 
        public string reason { get; set; } 
        public string text { get; set; } 
    }

    public class AnswerContent    {
        public Answer answer { get; set; } 
        public string answeredDateMessage { get; set; } 
        public int creationDate { get; set; } 
        public int customerId { get; set; } 
        public int id { get; set; } 
        public string imageUrl { get; set; } 
        public string productName { get; set; } 
        public bool @public { get; set; } 
        public string reason { get; set; } 
        public RejectedAnswer rejectedAnswer { get; set; } 
        public int rejectedDate { get; set; } 
        public string reportReason { get; set; } 
        public int reportedDate { get; set; } 
        public bool showUserName { get; set; } 
        public string status { get; set; } 
        public string text { get; set; } 
        public string userName { get; set; } 
        public string webUrl { get; set; } 
    }

    public class TrendyolCustomerQuestions    {
        public List<Content> content { get; set; } 
        public int page { get; set; } 
        public int size { get; set; } 
        public int totalElements { get; set; } 
        public int totalPages { get; set; } 
    }

}