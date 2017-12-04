using Invoice_Service.Interfaces;
using Invoice_Service.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Invoice_Service.Data
{   //CRUD ops. Async access to database
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly InvoiceContext _context = null;

        public InvoiceRepository(IOptions<Settings> settings)
        {
            _context = new InvoiceContext(settings);
        }

        public async Task<IEnumerable<Invoice>> GetAllinvoices()
        {
            try
            {
                var test = _context.Invoices.Find(_ => true);
                return await _context.Invoices.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
        public async Task<Invoice> GetInvoice(string id)
        {
            var inv = Builders<Invoice>.Filter.Eq("Id", id);

            try
            {
                return await _context.Invoices
                                .Find(inv)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<List<Invoice>> GetInvoiceByCustomer(string custId)
        {
            var inv = Builders<Invoice>.Filter.Eq("CustomerId", custId);

            try
            {
                return await _context.Invoices
                                .Find(inv).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddInvoice(Invoice invoice)
        {
            try
            {
                await _context.Invoices.InsertOneAsync(invoice);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<DeleteResult> RemoveInvoice(string id)
        {
            try
            {
                return await _context.Invoices.DeleteOneAsync(
                     Builders<Invoice>.Filter.Eq("InvoiceId", id));

            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<string> UpdateInvoice(string id, Invoice invoice)
        {
               await _context.Invoices.ReplaceOneAsync(i => i.InvoiceId.Equals(id)
                                                                , invoice
                                                                , new UpdateOptions { IsUpsert = true });
            return " ";
        }
    }
}


