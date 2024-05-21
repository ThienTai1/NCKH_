using Microsoft.AspNetCore.Mvc;
using NCKH.Models;
using System.Diagnostics;
using NCKH.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace NCKH.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerChurnContext _customerChurnContext;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, CustomerChurnContext customerChurnContext, ICustomerRepository customerRepository, HttpClient httpClient)
        {
            _logger = logger;
            _customerChurnContext = customerChurnContext;
            _customerRepository = customerRepository;
            _httpClient = httpClient;
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

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingCustomer = await _customerRepository.GetByIdAsync(id);
                    if (existingCustomer == null)
                    {
                        return NotFound();
                    }

                    await _customerRepository.UpdateAsync(customer);
                }
                catch (Exception)
                {
                    // Handle exception if needed
                    throw;
                }
                return RedirectToAction(nameof(Table));
            }
            return View(customer);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return RedirectToAction(nameof(Table));
            }

            await _customerRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Table));
        }



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Customer customer)
        {
            if (customer == null)
            {
                return View();
            }
            await _customerRepository.AddAsync(customer);
            return RedirectToAction(nameof(Table));
        }


        [HttpGet]
        public IActionResult Predict()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Predict(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Invalid customer data.");
            }

            try
            {
                var predictionRequest = new
                {
                    customerID = customer.CustomerId,
                    gender = customer.Gender,
                    SeniorCitizen = customer.SeniorCitizen,
                    Partner = customer.Partner,
                    Dependents = customer.Dependents,
                    tenure = customer.Tenure,
                    PhoneService = customer.PhoneService,
                    MultipleLines = customer.MultipleLines,
                    InternetService = customer.InternetService,
                    OnlineSecurity = customer.OnlineSecurity,
                    OnlineBackup = customer.OnlineBackup,
                    DeviceProtection = customer.DeviceProtection,
                    TechSupport = customer.TechSupport,
                    StreamingTV = customer.StreamingTv,
                    StreamingMovies = customer.StreamingMovies,
                    Contract = customer.Contract,
                    PaperlessBilling = customer.PaperlessBilling,
                    PaymentMethod = customer.PaymentMethod,
                    MonthlyCharges = customer.MonthlyCharges,
                    TotalCharges = customer.TotalCharges
                };


                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null
                };

                // Serialize the request to JSON
                var jsonPredictionRequest = JsonSerializer.Serialize(predictionRequest, options);

                // Create the content to send
                var content = new StringContent(jsonPredictionRequest, System.Text.Encoding.UTF8, "application/json");

                // Send the request
                var response = await _httpClient.PostAsync("http://localhost:5000/getPredictionOutput", content);

                if (response.IsSuccessStatusCode)
                {
                    var predictionResult = await response.Content.ReadAsStringAsync();
                    // Pass the prediction result to the view
                    ViewBag.PredictionResult = predictionResult;
                    return View("PredictionResult");
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Error from prediction API.");
                    /*var errorContent = await response.Content.ReadAsStringAsync();
                    return Ok(errorContent);*/

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}