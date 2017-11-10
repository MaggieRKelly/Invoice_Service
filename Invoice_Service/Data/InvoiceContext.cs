using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Invoice_Service.Models;
using Microsoft.Extensions.Options;

namespace Invoice_Service.Data
{
    public class InvoiceContext
    {
        private readonly IMongoDatabase _database = null;

        public InvoiceContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Invoice> Invoices
        {
            get
            {
                return _database.GetCollection<Invoice>("Invoice");
            }
        }
    }
  
}
