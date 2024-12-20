using C500Hemis.API;
using C500Hemis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace C500Hemis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiServices _apiServices;
        private readonly HemisContext _hemisContext;

        public HomeController(ILogger<HomeController> logger, ApiServices apiServices, HemisContext hemisContext)
        {
            _logger = logger;
            _apiServices = apiServices;
            _hemisContext = hemisContext;
        }

        public async Task<IActionResult> Index()
        {
            // List<TbCanBo> canBos = await _apiServices.GetAll<TbCanBo>("/api/cb/KyLuatCanBo");
            // return Content(JsonConvert.SerializeObject(canBos));
            // List<TbCanBo> canBos = await _hemisContext.TbCanBos.ToListAsync();
            // List<TbNguoi> nguoi = await _hemisContext.TbNguois.ToListAsync();
            // canBos.ForEach(t => t.IdNguoiNavigation = nguoi.Where(h => h.IdNguoi == t.IdNguoi).FirstOrDefault());
            // return Content(JsonConvert.SerializeObject(nguoi));
            return View();
        }

        public IActionResult CB()
        {
            return View();
        }

        public IActionResult HTQT()
        {
            return View();
        }

        public IActionResult CSGD ()
        {
            return View();
        }

        public IActionResult CSVC()
        {
            return View();
        }

        public IActionResult CTDT()
        {
            return View();
        }

        public IActionResult KHCN()
        {
            return View();
        }

        public IActionResult NDT()
        {
            return View();
        }

        public IActionResult NH()
        {
            return View();
        }

        public IActionResult TCTS()
        {
            return View();
        }

        public IActionResult TS()
        {
            return View();
        }

        public IActionResult VB()
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
