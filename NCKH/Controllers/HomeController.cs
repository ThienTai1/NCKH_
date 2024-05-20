using Microsoft.AspNetCore.Mvc;
using NCKH.Models;
using System.Diagnostics;
using NCKH.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            

            // Get the total number of rows
            int rowCount = _customerChurnContext.Customers.Count();

            // Pass the row count to the view using ViewBag or ViewModel
            ViewBag.RowCount = rowCount;
            // Get the total count of columns in the Order model
            int columnCount = GetColumnCount<Customer>();

            // Pass the column count to the view using ViewBag or ViewModel
            ViewBag.ColumnCount = columnCount;
            var customers = await allCustomer.ToListAsync();
            return View(customers);
        }


        public async Task<IActionResult> Display(string id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        // Hiển thị form cập nhật sản phẩm
        public async Task<IActionResult> Update(string id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                Console.WriteLine("Customer not found");
                return NotFound();
            }

            //Internet-related
            var availabilityOptionsInternet = new List<SelectListItem>
            {
                new SelectListItem { Value = "true", Text = "Yes" },
                new SelectListItem { Value = "false", Text = "No" },
                new SelectListItem { Value = "null", Text = "No internet" }
            };

            ViewBag.AvailabilityListInternet = new SelectList(availabilityOptionsInternet, "Value", "Text");

            //Phone service
            var availabilityOptionsPhone = new List<SelectListItem>
            {
                new SelectListItem { Value = "true", Text = "Yes" },
                new SelectListItem { Value = "false", Text = "No" },
                new SelectListItem { Value = "null", Text = "No phone service" }
            };
            ViewBag.AvailabilityListPhone = new SelectList(availabilityOptionsPhone, "Value", "Text");


            //Gender
            var availabilityOptionsGender = new List<SelectListItem>
            {
                new SelectListItem { Value = "true", Text = "Female" },
                new SelectListItem { Value = "false", Text = "Male" },
            };
            ViewBag.AvailabilityListGender = new SelectList(availabilityOptionsGender, "Value", "Text");

            //InternetService
            var availabilityOptionsService = new List<SelectListItem>
            {
                new SelectListItem { Value = "DSL", Text = "DSL" },
                new SelectListItem { Value = "Fiber Optic", Text = "Fiber Optic" },
                 new SelectListItem { Value = "No", Text = "No" }
            };
            ViewBag.AvailabilityListService = new SelectList(availabilityOptionsService, "Value", "Text");

            //Contract
            var availabilityOptionsContract = new List<SelectListItem>
            {
                new SelectListItem { Value = "Month-to-month", Text = "Month-to-month" },
                new SelectListItem { Value = "One year", Text = "One year" },
                new SelectListItem { Value = "Two year", Text = "Two year" }
            };
            ViewBag.AvailabilityListContract = new SelectList(availabilityOptionsContract, "Value", "Text");

            //PaymentMethod
            var availabilityOptionsPaymentMethod = new List<SelectListItem>
            {
                new SelectListItem { Value = "Mailed check", Text = "Mailed check" },
                new SelectListItem { Value = "Electronic check", Text = "Electronic check" },
                new SelectListItem { Value = "Credit card (automatic)", Text = "Credit card (automatic)" },
                new SelectListItem { Value = "Bank transfer (automatic)", Text = "Bank transfer (automatic)" }
            };
            ViewBag.AvailabilityListPaymentMethod = new SelectList(availabilityOptionsPaymentMethod, "Value", "Text");

            return View(customer);
        }
        // Xử lý cập nhật sản phẩm
        [HttpPost]
        public async Task<IActionResult> Update(string id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var existingCustomer = await _customerRepository.GetByIdAsync(id); // Giả định có phương thức GetByIdAsync

                // Cập nhật các thông tin khác của sản phẩm
                existingCustomer.Gender = customer.Gender;
                existingCustomer.SeniorCitizen = customer.SeniorCitizen;
                existingCustomer.Partner = customer.Partner;
                existingCustomer.Dependents = customer.Dependents;
                existingCustomer.Tenure= customer.Tenure;
                existingCustomer.PhoneService= customer.PhoneService;
                existingCustomer.MultipleLines= customer.MultipleLines;
                existingCustomer.InternetService= customer.InternetService;
                existingCustomer.OnlineSecurity= customer.OnlineSecurity;
                existingCustomer.OnlineBackup = customer.OnlineBackup;
                existingCustomer.DeviceProtection = customer.DeviceProtection;
                existingCustomer.TechSupport = customer.TechSupport;
                existingCustomer.StreamingTv = customer.StreamingTv;
                existingCustomer.StreamingMovies = customer.StreamingMovies;
                existingCustomer.Contract = customer.Contract;
                existingCustomer.MonthlyCharges = customer.MonthlyCharges;
                existingCustomer.TotalCharges = customer.TotalCharges;

                // Create a SelectList with boolean values and display text
                

                await _customerRepository.UpdateAsync(existingCustomer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        // Hiển thị form xác nhận xóa sản phẩm
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _customerRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // Xử lý xóa sản phẩm
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _customerRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private int GetColumnCount<T>()
        {
            return typeof(T).GetProperties().Length;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
