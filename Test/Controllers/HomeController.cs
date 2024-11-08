using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            HttpClient HttpClient = new HttpClient()
            {
                BaseAddress = new Uri(@"http://localhost:5225"),
            };
            HttpClient.DefaultRequestHeaders.Clear();
            HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            HttpResponseMessage httpResponse = await HttpClient.GetAsync("/api/CaNhan/Hoten");
            if (httpResponse.IsSuccessStatusCode)
            {
                string raw_data = await httpResponse.Content.ReadAsStringAsync();
                //string data = 
                return Content(await httpResponse.Content.ReadAsStringAsync());
            }
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
