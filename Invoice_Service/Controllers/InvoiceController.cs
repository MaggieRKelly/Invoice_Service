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
        public ActionResult Get()
        {
            var invoices = GetAllInvoices().Result;
            return View(invoices);
         
        }

        private async Task<IEnumerable<Invoice>> GetAllInvoices()
        {
            var inv = _invoiceRepository.GetAllinvoices();
            return await _invoiceRepository.GetAllinvoices();
        }

        // GET api/invoice/5
        [HttpGet("{Id}")]
        public Task<Invoice> GetById(string id)
        {

            return GetInvoiceById(id);
        }

        private async Task<Invoice> GetInvoiceById(string id)
        {
            var inv = _invoiceRepository.GetInvoice(id);
            return await _invoiceRepository.GetInvoice(id) ?? new Invoice();
        }

        // GET api/invoice/InvoicePending?=5
        [HttpGet("{InvoicePending}")]
        public Task<List<Invoice>> GetInvoiceByPending(bool pending)
        {


            return GetInvoicebyPendingId(pending);
        }

        private async Task<List<Invoice>> GetInvoicebyPendingId(bool pending)
        {
            var inv = _invoiceRepository.GetInvoiceByPending(pending);
            return await _invoiceRepository.GetInvoiceByPending(pending);
        }

        //// GET api/invoice?CustomerId=5
        //[HttpGet("{CustomerId}")]
        //public Task<List<Invoice>> GetInvoiceByCustomer(string custId)
        //{

        //    return GetInvoicebyCustomerId(custId);
        //}

        //private async Task<List<Invoice>> GetInvoicebyCustomerId(string custId)
        //{
        //    var inv = _invoiceRepository.GetInvoiceByCustomerId(custId);
        //    return await _invoiceRepository.GetInvoiceByCustomerId(custId);
        //}



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