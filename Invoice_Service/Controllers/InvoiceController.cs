using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Invoice_Service.Interfaces;
using Invoice_Service.Models;
using Invoice_Service.Infrastructure;

namespace Invoice_Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
            
        }

        [NoCache]
        [HttpGet]
        public Task<IEnumerable<Invoice>> Get()
        {
            return GetInvoiceInternal();
        }
        
        private async Task<IEnumerable<Invoice>> GetInvoiceInternal()
        {
            return await _invoiceRepository.GetAllinvoices();
        }
        
        // GET api/invoices/5
        [NoCache]
        [HttpGet("{id}")]
        public Task<Invoice> Get(string id)
        {
            return GetInvoiceByIdInternal(id);
        }

        private async Task<Invoice> GetInvoiceByIdInternal(string id)
        {
            return await _invoiceRepository.GetInvoice(id) ?? new Invoice();
        }

        // POST api/invoices
        [HttpPost]
        public void Post([FromBody]string orderRef, string orderTotal, string customerId, string customerName, string customerAddress, string InvoiceTotal, string InvoiceDate)
        {
            _invoiceRepository.AddInvoice(new Invoice() { OrderRef = orderRef, OrderTotal = orderTotal, CustomerId = customerId, CustomerName = customerName, CustomerAddress = customerAddress, InvoiceTotal = InvoiceTotal, InvoiceDate = InvoiceDate, InvoicePending = true });
        }

        // PUT api/invoices/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] bool InvoicePending)
        {
            _invoiceRepository.UpdateInvoice (id, InvoicePending);
        }

        // DELETE api/invoices/
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _invoiceRepository.RemoveInvoice(id);
        }


    }
}