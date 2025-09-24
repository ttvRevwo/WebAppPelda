using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAppPelda.Models;
using WebAppPelda.Controllers;

namespace WebAppPelda.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult SubPage()
        {
            Customer customer = new Customer
            {
                Id = 1,
                Name = "John Doe",
                Phone = "123-456-7890",
                Score = 85
            };
            return View(customer);
        }

        public IActionResult CustomerList()
        {
            List<Customer> customers = new CustomerController().GetCustomersFromDatabase();
            return View(customers);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
