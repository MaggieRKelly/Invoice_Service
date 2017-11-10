using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Invoice_Service.Models
{
    public class Invoice
    {
        [BsonId]
        public string InvoiceId { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public List <string> OrderId { get; set; }
        public List<string> ProductId { get; set; }
        public List<string> ProductName { get; set; }
        public List<double> ProductPrice { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public double InvoiceTotal { get; set; }
        public Boolean InvoicePending { get; set; }
    }
}
