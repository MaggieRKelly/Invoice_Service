using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Service.Models;
using MongoDB.Bson;

namespace Invoice_Service.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllinvoices();
        Task<Invoice> GetInvoice(string id);
        // add new invoice document
        Task AddInvoice(Invoice item);
        // remove a single document
        Task<bool> RemoveInvoice(string id);
        // update a single document
        Task<bool> UpdateInvoice(string id, bool invPend );

    }
}
//public string InvoiceId { get; set; }
//public DateTime UpdatedOn { get; set; } = DateTime.Now;
//public DateTime CreatedOn { get; set; } = DateTime.Now;
//public List<string> OrderId { get; set; }
//public List<string> ProductId { get; set; }
//public List<string> ProductName { get; set; }
//public List<double> ProductPrice { get; set; }
//public string CustomerId { get; set; }
//public string CustomerName { get; set; }
//public string CustomerAddress { get; set; }
//public double InvoiceTotal { get; set; }
//public Boolean InvoicePending { get; set; }