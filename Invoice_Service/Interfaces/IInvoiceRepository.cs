using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Service.Models;
using MongoDB.Bson;

namespace Invoice_Service.Interfaces
{
    //
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

