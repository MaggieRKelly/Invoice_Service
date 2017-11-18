using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice_Service.Models;
using MongoDB.Driver;

namespace Invoice_Service.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllinvoices();
        Task<Invoice> GetInvoice(string id);
        // add new invoice document
        Task AddInvoice(Invoice invoice);
        // remove a single document
        Task<DeleteResult> RemoveInvoice(string id);
        // update a single document
        Task<string> UpdateInvoice(string id, Invoice invoice);

    }
}

