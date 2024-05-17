using Microsoft.AspNetCore.Mvc;
using NCKH.Models;
using System.Diagnostics;
using NCKH.Repositories;
using Microsoft.EntityFrameworkCore;
namespace NCKH.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerChurnContext _customerChurnContext;

        public HomeController(ILogger<HomeController> logger, CustomerChurnContext customerChurnContext, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerChurnContext = customerChurnContext;
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Chart()
        {
            return View();
        }

        public async Task<IActionResult> Table()
        {
            var allCustomer = _customerChurnContext.Customers.AsQueryable();
            var customers = await allCustomer.ToListAsync();
            return View(customers);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
