using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using Invoice_Service.Controllers;
using Invoice_Service.Data;
using Invoice_Service.Models;
using Microsoft.Extensions.Options;

namespace XUnitTestInvoiceService
{
    public class UnitTest1
    {
        private IOptions<Settings> inv;

        [Fact]
    public async Task Invoice_Get_All()
    {
        // Arrange
        var controller = new InvoiceController(new InvoiceRepository(this.inv));

        // Act
        var result = await controller.Get();

        // Assert
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        var inv = okResult.Value.Should().BeAssignableTo<IEnumerable<Invoice>>().Subject;

        inv.Count().Should().Be(50);
    }

    [Fact]
    public async Task Values_Get_Specific()
    {
        // Arrange
        var controller = new InvoiceController(new InvoiceRepository(inv));

        // Act
        var result = await controller.Get();

        // Assert
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        var invoice = okResult.Value.Should().BeAssignableTo<Invoice>().Subject;
        invoice.Id.Should().Be("");
    }

    [Fact]
    public async Task Invoice_Add()
    {
        // Arrange
        var controller = new InvoiceController(new InvoiceRepository(inv));
        var newInvoice = new Invoice
        {
            CustomerName = "John",
            CustomerLastName = "Doe",
            CustoRef = "john.doe@foo.bar",
            OrderRef = "Ord1",
            OrderTotal = "£50.00",
            InvoicePending = true
        };

        // Act
        var result = await controller.Post(newInvoice);

        // Assert
        var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
        var invoice = okResult.Value.Should().BeAssignableTo<Invoice>().Subject;
        invoice.Id.Should().Be("");
    }

    [Fact]
    public async Task Invoice_Change()
    {
        // Arrange
        var service = new InvoiceRepository(inv);
        var controller = new InvoiceController(service);
        var newInvoice = new Invoice
        {
            CustomerName = "John",
            CustomerLastName = "Doe",
            CustomerId = "Cust50",
            CustoRef = "Custo50@test.com",
            OrderTotal = "£300.99",
            OrderDate = "05/12/17"
        };

    }
}
}
