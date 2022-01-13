using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using OdataOrders.Data;

namespace OdataOrders.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class CustomersController : ODataController
    {
        private readonly OdataOrdersContext context;

        public CustomersController(OdataOrdersContext context)
        {
            this.context = context;
        }

        //[HttpGet]
        //[EnableQuery]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Ok(await context.Customers.ToArrayAsync());
        //}

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(context.Customers);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            return Ok(customer);
        }

        private readonly List<string> demoCustomers = new List<string>
        {
            "Foo",
            "Bar",
            "Acme",
            "King of Tech",
            "Awesomeness"
        };

        private readonly List<string> demoProducts = new List<string>
        {
            "Bike",
            "Car",
            "Apple",
            "Spaceship"
        };

        private readonly List<string> demoCountries = new List<string>
        {
            "AT",
            "DE",
            "CH"
        };

        [HttpPost]
        [Route("fill")]
        public async Task<IActionResult> Fill()
        {
            var rand = new Random();
            for (var i = 0; i < 10; i++)
            {
                var c = new Customer
                {
                    CustomerName = demoCustomers[rand.Next(demoCustomers.Count)],
                    CountryId = demoCountries[rand.Next(demoCountries.Count)]
                };
                context.Customers.Add(c);

                for (var j = 0; j < 10; j++)
                {
                    var o = new Order
                    {
                        OrderDate = DateTime.Today,
                        Product = demoProducts[rand.Next(demoProducts.Count)],
                        Quantity = rand.Next(1, 5),
                        Revenue = rand.Next(100, 5000),
                        Customer = c
                    };
                    context.Orders.Add(o);
                }
            }

            await context.SaveChangesAsync();
            return Ok();
        }
    }
}

