using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Invoice_Service.Interfaces;
using Invoice_Service.Models;
using Invoice_Service.Infrastructure;
using MongoDB.Driver;
using System.Diagnostics;

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

       // [NoCache]
        [HttpGet]
        public Task<IEnumerable<Invoice>> Get()
        {
            return GetInvoice();
        }
        
        private async Task<IEnumerable<Invoice>> GetInvoice()
        {
            var tes = _invoiceRepository.GetAllinvoices();
            return await _invoiceRepository.GetAllinvoices();
        }
        
        // GET api/invoices/5
        //[NoCache]
        [HttpGet("{Id}")]
        public Task<Invoice> Get(string id)
        {
            return GetInvoiceById(id);
        }

        private async Task<Invoice> GetInvoiceById(string id)
        {
            return await _invoiceRepository.GetInvoice(id) ?? new Invoice();
        }

        // POST api/invoice
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _invoiceRepository.AddInvoice(new Invoice()
            {
                OrderRef = value,
                OrderTotal = value,
                CustomerId = value,
                CustomerName = value,
                CustomerAddress = value,
                InvoiceTotal = value,
                InvoiceDate = value,
                InvoicePending = true});

            }

        // PUT api/invoice/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] bool InvoicePending)
        {
            _invoiceRepository.UpdateInvoice (id, InvoicePending);
        }

        // DELETE api/invoice/
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _invoiceRepository.RemoveInvoice(id);
        }


    }
}