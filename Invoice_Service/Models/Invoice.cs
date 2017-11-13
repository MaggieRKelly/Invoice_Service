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
        public string OrderRef { get; set; }
        public string OrderDate { get; set; }
        public string OrderTotal { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string InvoiceTotal { get; set; }
        public Boolean InvoicePending { get; set; }
    }
}
