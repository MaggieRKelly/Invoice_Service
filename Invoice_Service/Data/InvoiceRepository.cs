using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using Invoice_Service.Interfaces;
using Invoice_Service.Models;


namespace Invoice_Service.Data
{
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
                var test = _context.Invoices;
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
            var filter = Builders<Invoice>.Filter.Eq("InvoiceId", id);

            try
            {
                return await _context.Invoices
                                .Find(filter)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddInvoice(Invoice item)
        {
            try
            {
                await _context.Invoices.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveInvoice(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Invoices.DeleteOneAsync(
                     Builders<Invoice>.Filter.Eq("InvoiceId", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateInvoice(string id, bool invPend)
        {
            var filter = Builders<Invoice>.Filter.Eq(s => s.InvoiceId, id);
            var update = Builders<Invoice>.Update
                            .Set(s => s.InvoicePending, invPend);
                           

            try
            {
                UpdateResult actionResult = await _context.Invoices.UpdateOneAsync(filter, update);

                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateInvoice(string id, Invoice item)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.Invoices
                                                .ReplaceOneAsync(i => i.InvoiceId.Equals(id)
                                                                , item
                                                                , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

    }
}


