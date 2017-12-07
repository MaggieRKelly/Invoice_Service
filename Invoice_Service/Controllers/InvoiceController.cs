using Invoice_Service.Interfaces;
using Invoice_Service.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Invoice_Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;

        }

        // GET api/invoice
        [HttpGet]
        public Task<IEnumerable<Invoice>> Get()
        {
            return GetAllInvoices();
        }

        private async Task<IEnumerable<Invoice>> GetAllInvoices()
        {
            var inv = _invoiceRepository.GetAllinvoices();
            return await _invoiceRepository.GetAllinvoices();
        }

        // GET api/invoice?CustomerId=5
        [HttpGet("{CustomerId}")]
        public Task<List<Invoice>> GetInvoiceByCustomer(string custId)
        {
            return GetInvoicebyCustomer(custId);
        }

        private async Task<List<Invoice>> GetInvoicebyCustomer(string custId)
        {

            return await _invoiceRepository.GetInvoiceByCustomer(custId);
        }

        // GET api/invoice/5
        [HttpGet("{Id}")]
        public Task<Invoice> GetById(string id)
        {
            //if()
            return GetInvoiceById(id);
        }

        private async Task<Invoice> GetInvoiceById(string id)
        {
            return await _invoiceRepository.GetInvoice(id) ?? new Invoice();
        }

        // POST api/invoice
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] Invoice order)
        { 
            await _invoiceRepository.AddInvoice(order);
            var t = CreatedAtAction("Get", new { id = order.OrderRef }, order);
            Invoice x = (Invoice) t.Value;
            var r = x.getReady();
            

            var content = new FormUrlEncodedContent(r);
            return await client.PostAsync("https://enigmatic-cove-40131.herokuapp.com/message/", content);
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