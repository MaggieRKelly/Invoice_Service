using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice_Service.Models;
using MongoDB.Driver;

namespace Invoice_Service.Interfaces
{
    public interface IInvoiceRepository
    {
        object Invoices { get; }

        Task<IEnumerable<Invoice>> GetAllinvoices();
        Task<Invoice> GetInvoice(string id);
        //Task<List<Invoice>> GetInvoiceByCustomerId(string custId);
        Task<List<Invoice>> GetInvoiceByPending(bool pending);
        // add new invoice document
        Task AddInvoice(Invoice invoice);
        // remove a single document
        Task<DeleteResult> RemoveInvoice(string id);
        // update a single document
        Task<string> UpdateInvoice(string id, Invoice invoice);

    }
}

