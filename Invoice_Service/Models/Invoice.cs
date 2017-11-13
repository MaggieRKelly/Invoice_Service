﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Invoice_Service.Models
{
    public class Invoice
    {
        //[BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("invoiceId")]
        public string InvoiceId { get; set; }
        [BsonElement("Invoicedate")]
        public string InvoiceDate { get; set; }
        [BsonElement("OrderRef")]
        public string OrderRef { get; set; }
        [BsonElement("OrderDate")]
        public string OrderDate { get; set; }
        [BsonElement("OrderTotal")]
        public string OrderTotal { get; set; }
        [BsonElement("CustomerId")]
        public string CustomerId { get; set; }
        [BsonElement("CustomerName")]
        public string CustomerName { get; set; }
        [BsonElement("CustomerAddress")]
        public string CustomerAddress { get; set; }
        [BsonElement("invoiceTotal")]
        public string InvoiceTotal { get; set; }
        [BsonElement("InvoicePending")]
        public Boolean InvoicePending { get; set; }
    }
}
