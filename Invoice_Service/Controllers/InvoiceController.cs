using Invoice_Service.Interfaces;
using Invoice_Service.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [HttpGet]
        public Task<IEnumerable<Invoice>> Get()
        {
            return GetInvoice();
        }

        private async Task<IEnumerable<Invoice>> GetInvoice()
        {
            var inv = _invoiceRepository.GetAllinvoices();
            return await _invoiceRepository.GetAllinvoices();
        }

        // GET api/invoices/5
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
        public async Task<IActionResult> Post([FromBody]string order, [FromBody]Invoice invoice)
        {
            var token = Request.Headers["authorization"][1];
            invoice.OrderRef = Request.Form["OrderRef"];
            invoice.OrderTotal = Request.Form["OrderTotal"];
            invoice.CustomerId = Request.Form["CustoRef"];
            await _invoiceRepository.AddInvoice(invoice);
            return CreatedAtAction("Get", new { id = invoice.InvoiceId }, invoice);

        }

        // PUT api/invoice/5
        [HttpPut("{Id}")]
        public async Task<string> Put(string id, [FromBody] Invoice invoice)
        {
            if (string.IsNullOrEmpty(id))
                return "Invalid id!";

            return await _invoiceRepository.UpdateInvoice(id, invoice);
        }

        // DELETE api/invoice/
        [HttpDelete("{Id}")]
        public async Task<string> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return "Invalid id!";

            await _invoiceRepository.RemoveInvoice(id);
            return "";
        }


    }
}