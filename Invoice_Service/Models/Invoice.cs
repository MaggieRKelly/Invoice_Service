using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Invoice_Service.Models
{
    public class Invoice
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string InvoiceId { get; set; }
        public string Invoicedate { get; set; }
        public string OrderRef { get; set; }
        public string OrderDate { get; set; }
        public string OrderTotal { get; set; }
        public string CustomerId { get; set; }
        public string CustoRef { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string InvoiceTotal { get; set; }
        public bool InvoicePending { get; set; }
        public string CustomerLastName { get; set; }

        public Dictionary<string, string> getReady()
        {
            return new Dictionary<string, string>
            {
                 { "messageTo", CustoRef },
                     { "content", "New Invoice pending " + InvoiceTotal}
                };
        }
}
}
